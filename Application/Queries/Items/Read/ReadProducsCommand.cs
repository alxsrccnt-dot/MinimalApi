using Application.Common;
using MediatR;

namespace Application.Queries.Items.Read;

public record ReadDocumentsCommand(PaginatedRequest<FilterByItemsColumn> ReadIProductsRequest) : IRequest<PaginatedResultDto<ProductDto>>;