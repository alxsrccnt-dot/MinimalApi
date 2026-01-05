using Application.Commands.Products.Create;
using Application.Commands.Products.Update;
using Application.Common;
using Application.Queries.Items.Read;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Endpoints;

public class ProductsEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/products")
			.RequireAuthorization();

		group.MapGet("", GetItems)
			.WithName(nameof(GetItems));

		var adminGroup = app.MapGroup("/api/admin/products")
			.AllowAnonymous();
			//.RequireAuthorization();

		adminGroup.MapPost("", AddProduct)
			.WithName(nameof(AddProduct));

		adminGroup.MapPut("", UpdateProduct)
			.WithName(nameof(UpdateProduct));
	}

	public async Task<IResult> GetItems([FromServices] IMediator mediator,
			FilterByItemsColumn? filterByColumn,
			string? filterValue,
			int pageNumber = 1,
			int pageSize = 10)
	{
		var readItemsRequest = new PaginatedRequest<FilterByItemsColumn>
		{
			FilterByColumn = filterByColumn is not null ? filterByColumn.Value : FilterByItemsColumn.None,
			FilterValue = filterValue,
			PageNumber = pageNumber,
			PageSize = pageSize
		};
		var paginedDto = await mediator.Send(new ReadDocumentsCommand(readItemsRequest));

		if (paginedDto.IsEmpty())
			return Results.NotFound("No items found.");

		return Results.Ok(paginedDto);
	}

	public async Task<IResult> AddProduct([FromServices] IMediator mediator,
		[FromBody]CreateProductRequest request)
	{
		await mediator.Send(new CreateProductCommand(request));
		return Results.Ok("The product was added.");
	}

	public async Task<IResult> UpdateProduct([FromServices] IMediator mediator,
		[FromBody] UpdateProductRequest request)
	{
		await mediator.Send(new UpdateProductCommand(request));
		return Results.Ok("The product was updated.");
	}
}