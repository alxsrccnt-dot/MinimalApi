using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Licenses.Update;
using Application.Licenses.Create;

namespace MainApi.Endpoints;

public class LicensesEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var adminGroup = app.MapGroup("/api/admin/licenses")
			.AllowAnonymous();

		adminGroup.MapPost("", AddLicense)
			.WithName(nameof(AddLicense));

		adminGroup.MapPut("", UpdateLicense)
			.WithName(nameof(UpdateLicense));
	}

	public async Task<IResult> AddLicense([FromServices] IMediator mediator,
		[FromBody] CreateLicenseRequest request)
	{
		await mediator.Send(new CreateLicenseCommand(request));
		return Results.Ok("License added.");
	}

	public async Task<IResult> UpdateLicense([FromServices] IMediator mediator,
		[FromBody] UpdateLicenseRequest request)
	{
		await mediator.Send(new UpdateLicenseCommand(request));
		return Results.Ok("License updated.");
	}
}