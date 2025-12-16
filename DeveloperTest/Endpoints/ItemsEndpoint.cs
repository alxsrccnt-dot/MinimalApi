using Application.Common;
using Application.Items.Read;
using Carter;
using MediatR;

namespace DeveloperTest.Endpoints;

public class ItemsEndpoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/items")
			   .RequireAuthorization();

		group.MapGet("", GetItems)
			.WithName(nameof(GetItems));
	}

	public async Task<IResult> GetItems(IMediator mediator,
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
		var paginedDto = await mediator.Send(new ReadItemsCommand(readItemsRequest));

		if (paginedDto.IsEmpty())
			return Results.NotFound("No items found.");

		return Results.Ok(paginedDto);
	}
}