using Application.Common;
using MediatR;

namespace Application.Products.Read;

public class ReadProductsCommandHandler : IRequestHandler<ReadDocumentsCommand, PaginatedResultDto<ProductDto>>
{
	public async Task<PaginatedResultDto<ProductDto>> Handle(ReadDocumentsCommand command, CancellationToken cancellationToken)
	{
		return null;
		//var searchInfo = command.ReadIProductsRequest;
		//var productsQuery = context.Products.AsQueryable();

		//productsQuery = productsQuery.OrderBy(i => i.Id)
		//	.Skip(searchInfo.PageSize * searchInfo.PageNumber)
		//	.Take(searchInfo.PageNumber);

		//var totalCount = await productsQuery.CountAsync(cancellationToken);
		//var productsDtos = await productsQuery
		//	.AsNoTracking()
		//	.Select(product => new ProductDto(product.Code, product.Title, product.Description))
		//	.ToListAsync(cancellationToken);

		//return new PaginatedResultDto<ProductDto>
		//{
		//	Data = productsDtos,
		//	TotalCount = totalCount,
		//	PageNumber = searchInfo.PageNumber,
		//	PageSize = searchInfo.PageSize,
		//	TotalPages = (int)Math.Ceiling(totalCount / (double)searchInfo.PageSize)
		//};
	}
}