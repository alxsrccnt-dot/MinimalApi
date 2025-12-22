using Application.Common;
using MediatR;

namespace Application.Items.Read;

public record ReadDocumentsCommand(PaginatedRequest<FilterByItemsColumn> ReadItemsRequest) : IRequest<PaginatedResultDto<OrderDto>>;