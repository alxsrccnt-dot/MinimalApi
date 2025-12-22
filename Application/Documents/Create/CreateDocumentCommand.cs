using MediatR;

namespace Application.Documents.Create;

public record CreateDocumentCommand(CreateDocumentRequest Request) : IRequest;