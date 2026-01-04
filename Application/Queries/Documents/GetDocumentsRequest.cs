using Application.Common;
using Application.Queries.Documents.Read;
using MediatR;

namespace Application.Queries.Documents;

public class GetDocumentsRequest(PaginatedRequest<FilterByOrdersColumn> request) : IRequest;