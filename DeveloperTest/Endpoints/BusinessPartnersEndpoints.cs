using Application.BusinessPartners.Create;
using Application.BusinessPartners.Read;
using Application.BusinessPartners.Update;
using Application.Common;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Endpoints;

public class BusinessPartnersEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/business-partners")
			.RequireAuthorization();

		group.MapGet("", GetBusinessPartners)
			.WithName(nameof(GetBusinessPartners));

		var adminGroup = app.MapGroup("/api/admin/business-partners")
			.RequireAuthorization("admins.manage");

		adminGroup.MapPost("", AddBusinessPartners)
			.WithName(nameof(AddBusinessPartners));

		adminGroup.MapPut("", UpdateBusinessPartners)
			.WithName(nameof(UpdateBusinessPartners));
	}

	public async Task<IResult> GetBusinessPartners(IMediator mediator,
			FilterByBusinessPartnersColumn? filterByColumn,
			string? filterValue,
			int pageNumber = 1,
			int pageSize = 10)
	{
		var readBusinessPartnerRequest = new PaginatedRequest<FilterByBusinessPartnersColumn>
		{
			FilterByColumn = filterByColumn is not null ? filterByColumn.Value : FilterByBusinessPartnersColumn.None,
			FilterValue = filterValue,
			PageNumber = pageNumber,
			PageSize = pageSize
		};
		var paginedDto = await mediator.Send(new ReadBusinessPartnersCommand(readBusinessPartnerRequest));

		if (paginedDto.IsEmpty())
			return Results.NotFound("No business partner found.");

		return Results.Ok(paginedDto);
	}
	public async Task<IResult> AddBusinessPartners([FromServices] IMediator mediator,
		[FromBody] CreateBusinessPartnerRequest request)
	{
		await mediator.Send(new CreateBusinessPartnerCommand(request));
		return Results.Ok("New business partner added.");
	}

	public async Task<IResult> UpdateBusinessPartners([FromServices] IMediator mediator,
		[FromBody] UpdateBusinessPartnerRequest request)
	{
		await mediator.Send(new UpdateBusinessPartnerCommand(request));
		return Results.Ok("Business partner updated.");
	}
}