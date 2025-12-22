using Application.Common;
using Application.Documents.Read;
using MediatR;

namespace Application.Documents;

public class GetDocumentsRequest(PaginatedRequest<FilterByOrdersColumn> request) : IRequest;