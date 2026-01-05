using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Application.Commands.Categories.Create;

namespace MainApi.Endpoints;

public class CategoryEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var adminGroup = app.MapGroup("/api/admin/categories")
			.AllowAnonymous();

		adminGroup.MapPost("", AddCategory)
			.WithName(nameof(AddCategory));
	}

	public async Task<IResult> AddCategory([FromServices] IMediator mediator,
		[FromBody] CreateCategoryRequest request)
	{
		await mediator.Send(new CreateCategoryCommand(request));
		return Results.Ok("Category added.");
	}
}