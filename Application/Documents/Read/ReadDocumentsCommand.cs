using Application.Common;
using MediatR;

namespace Application.Documents.Read;

public record ReadDocumentsCommand(PaginatedRequest<FilterByOrdersColumn> Request) : IRequest<PaginatedResultDto<OrderDto>>;