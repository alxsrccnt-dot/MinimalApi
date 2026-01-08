using MediatR;

namespace Application.Inventories.Create;

public record CreateInventoryCommand(CreateInventoryRequest Request) : IRequest;