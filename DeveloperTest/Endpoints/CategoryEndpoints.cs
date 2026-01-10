using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Categories.Create;
using Application.Categories.Update;

namespace MainApi.Endpoints;

public class CategoryEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var adminGroup = app.MapGroup("/api/admin/categories")
			.RequireAuthorization("admins.manage");

		adminGroup.MapPost("", AddCategory)
			.WithName(nameof(AddCategory));

		adminGroup.MapPut("", UpdateCategory)
			.WithName(nameof(UpdateCategory));
	}

	public async Task<IResult> AddCategory([FromServices] IMediator mediator,
		[FromBody] CreateCategoryRequest request)
	{
		await mediator.Send(new CreateCategoryCommand(request));
		return Results.Ok("Category added.");
	}

	public async Task<IResult> UpdateCategory([FromServices] IMediator mediator,
		[FromBody] UpdateCategoryRequest request)
	{
		await mediator.Send(new UpdateCategoryCommand(request));
		return Results.Ok("Category updated.");
	}
}