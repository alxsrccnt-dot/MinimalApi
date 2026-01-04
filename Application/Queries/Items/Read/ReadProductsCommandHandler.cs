using Application.Common;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Items.Read;

public class ReadProductsCommandHandler                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        (ApplicationDbContext context) : IRequestHandler<ReadDocumentsCommand, PaginatedResultDto<ProductDto>>
{
	public async Task<PaginatedResultDto<ProductDto>> Handle(ReadDocumentsCommand command, CancellationToken cancellationToken)
	{
		var searchInfo = command.ReadIProductsRequest;
		var productsQuery = context.Products.AsQueryable();

		productsQuery = productsQuery.OrderBy(i => i.Id)
			.Skip(searchInfo.PageSize * searchInfo.PageNumber)
			.Take(searchInfo.PageNumber);

		var totalCount = await productsQuery.CountAsync(cancellationToken);
		var productsDtos = await productsQuery
			.AsNoTracking()
			.Select(product => new ProductDto(product.Code, product.Title, product.Description))
			.ToListAsync(cancellationToken);

		return new PaginatedResultDto<ProductDto>
		{
			Data = productsDtos,
			TotalCount = totalCount,
			PageNumber = searchInfo.PageNumber,
			PageSize = searchInfo.PageSize,
			TotalPages = (int)Math.Ceiling(totalCount / (double)searchInfo.PageSize)
		};
	}
}