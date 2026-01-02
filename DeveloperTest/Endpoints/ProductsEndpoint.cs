using Application.Commands.Products.Create;
using Application.Common;
using Application.Items.Create;
using Application.Items.Read;
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

		adminGroup.MapPost("", AddItem)
			.WithName(nameof(AddItem));

		adminGroup.MapPut("", UpdateItem)
			.WithName(nameof(UpdateItem));
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

	public async Task<IResult> AddItem([FromServices] IMediator mediator,
		[FromBody]CreateItemRequest request)
	{
		await mediator.Send(new CreateProductCommand());
		return Results.Ok("Item was added.");
	}

	public async Task<IResult> UpdateItem()
	{
		return Results.Ok("Item was added.");
	}
}