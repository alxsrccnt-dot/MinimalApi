using MediatR;

namespace Application.Commands.Warehouses.Create;

public record CreateWarehouseCommand(CreateWarehouseRequest Request) : IRequest;