using Application.Common;
using MediatR;

namespace Application.Orders.Read;

public record ReadDocumentsCommand(PaginatedRequest<FilterByOrdersColumn> Request) : IRequest<PaginatedResultDto<OrderDto>>;