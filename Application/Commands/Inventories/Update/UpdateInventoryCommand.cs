using MediatR;

namespace Application.Commands.Inventories.Update;

public record UpdateInventoryCommand(UpdateInventoryRequest Request) : IRequest;