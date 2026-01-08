using MediatR;

namespace Application.Inventories.Update;

public record UpdateInventoryCommand(UpdateInventoryRequest Request) : IRequest;