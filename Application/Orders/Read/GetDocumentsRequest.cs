using Application.Common;
using MediatR;

namespace Application.Orders.Read;

public class GetDocumentsRequest(PaginatedRequest<FilterByOrdersColumn> request) : IRequest;