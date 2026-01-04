using MediatR;

namespace Application.Commands.Orders.Create;

public record CreateDocumentCommand(CreateDocumentRequest Request) : IRequest;