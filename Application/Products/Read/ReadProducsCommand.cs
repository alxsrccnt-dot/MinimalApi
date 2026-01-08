using Application.Common;
using MediatR;

namespace Application.Products.Read;

public record ReadDocumentsCommand(PaginatedRequest<FilterByItemsColumn> ReadIProductsRequest) : IRequest<PaginatedResultDto<ProductDto>>;