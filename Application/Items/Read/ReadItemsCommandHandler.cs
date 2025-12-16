using Application.Common;
using Application.Items.Read;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Items.ReadItems;

public class ReadIBusinessPartnersCommandHandler(ApplicationDbContext context) : IRequestHandler<ReadItemsCommand, PaginatedResultDto<ItemDto>>
{
	public async Task<PaginatedResultDto<ItemDto>> Handle(ReadItemsCommand command, CancellationToken cancellationToken)
	{
		var searchInfo = command.ReadItemsRequest;
		var itemsQuery = context.Items.AsQueryable();

		var filterValue = searchInfo.FilterValue;
		itemsQuery = filterValue is null && searchInfo.FilterByColumn is not FilterByItemsColumn.None
			? itemsQuery
			: searchInfo.FilterByColumn switch
			{
				FilterByItemsColumn.ItemCode => itemsQuery.Where(i => i.ItemCode == filterValue),
				FilterByItemsColumn.ItemName => itemsQuery.Where(i => i.ItemName == filterValue),
				FilterByItemsColumn.Active => itemsQuery.Where(i => i.Active) //to do
			};

		itemsQuery = 
			itemsQuery.OrderBy(i => i.ItemCode)
			.Skip(searchInfo.PageSize * searchInfo.PageNumber)
			.Take(searchInfo.PageNumber);

		var totalCount = await itemsQuery.CountAsync(cancellationToken);
		var itemsDtos = await itemsQuery
			.Select(item => new ItemDto(item.ItemCode, item.ItemName, item.Active))
			.ToListAsync(cancellationToken);

		return new PaginatedResultDto<ItemDto>
		{
			Data = itemsDtos,
			TotalCount = totalCount,
			PageNumber = searchInfo.PageNumber,
			PageSize = searchInfo.PageSize,
			TotalPages = (int)Math.Ceiling(totalCount / (double)searchInfo.PageSize)
		};
	}
}