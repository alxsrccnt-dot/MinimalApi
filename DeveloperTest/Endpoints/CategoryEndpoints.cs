using Application.Commands.Categories.Create;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Endpoints;

public class CategoryEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/categories")
			.RequireAuthorization();

		var adminGroup = app.MapGroup("/api/admin/categories")
			.AllowAnonymous();

		adminGroup.MapPost("", AddCategory)
			.WithName(nameof(AddCategory));
	}

	public async Task<IResult> AddCategory([FromServices] IMediator mediator,
		[FromBody] CreateCategoryRequest request)
	{
		await mediator.Send(new CreateCategoryCommand(request));
		return Results.Ok("Category was added.");
	}
}