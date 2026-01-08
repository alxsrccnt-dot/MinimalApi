using MediatR;

namespace Application.Warehouses.Create;

public record CreateWarehouseCommand(CreateWarehouseRequest Request) : IRequest;