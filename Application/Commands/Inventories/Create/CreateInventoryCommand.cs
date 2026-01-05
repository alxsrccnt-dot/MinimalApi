using MediatR;

namespace Application.Commands.Inventories.Create;

public record CreateInventoryCommand(CreateInventoryRequest Request) : IRequest;