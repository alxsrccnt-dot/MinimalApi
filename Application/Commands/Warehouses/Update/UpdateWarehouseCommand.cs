using MediatR;

namespace Application.Commands.Warehouses.Update;

public record UpdateWarehouseCommand(UpdateWarehouseRequest Request) : IRequest;