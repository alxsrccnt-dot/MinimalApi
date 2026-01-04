using Application.Common;
using MediatR;

namespace Application.Queries.Documents.Read;

public record ReadDocumentsCommand(PaginatedRequest<FilterByOrdersColumn> Request) : IRequest<PaginatedResultDto<OrderDto>>;