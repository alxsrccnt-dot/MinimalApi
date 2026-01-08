using Application.Common;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.Read;

public class ReadDocumentsCommandHandler() : IRequestHandler<ReadDocumentsCommand, PaginatedResultDto<OrderDto>>
{
	public async Task<PaginatedResultDto<OrderDto>> Handle(ReadDocumentsCommand command, CancellationToken cancellationToken)
	{
		//var searchInfo = command.Request;

		//var ordersQuery = context.Orders.AsQueryable();

		//var filterValue = searchInfo.FilterValue;
		//ordersQuery = filterValue is not null && searchInfo.FilterByColumn is not FilterByOrdersColumn.None
		//	? ordersQuery
		//	: searchInfo.FilterByColumn switch
		//	{
		//		FilterByOrdersColumn.CreatedBy => ordersQuery.Where(i => i.CreatedBy == filterValue),
		//		FilterByOrdersColumn.CreateDate => ordersQuery.Where(i => i.CreateAt.ToString() == filterValue) //to do
		//	};

		//ordersQuery =
		//	ordersQuery.OrderBy(i => i.CreateAt)
		//	.Skip(searchInfo.PageSize * searchInfo.PageNumber)
		//	.Take(searchInfo.PageNumber);

		//var totalCount = await ordersQuery.CountAsync(cancellationToken);
		//var itemsDtos = await ordersQuery
		//	.Select(item => new OrderDto())
		//	.ToListAsync(cancellationToken);

		//return new PaginatedResultDto<OrderDto>
		//{
		//	Data = itemsDtos,
		//	TotalCount = totalCount,
		//	PageNumber = searchInfo.PageNumber,
		//	PageSize = searchInfo.PageSize,
		//	TotalPages = (int)Math.Ceiling(totalCount / (double)searchInfo.PageSize)
		//};


		return null;
	}
}