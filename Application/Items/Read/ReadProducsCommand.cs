using Application.Common;
using MediatR;

namespace Application.Items.Read;

public record ReadDocumentsCommand(PaginatedRequest<FilterByItemsColumn> ReadIProductsRequest) : IRequest<PaginatedResultDto<ProductDto>>;