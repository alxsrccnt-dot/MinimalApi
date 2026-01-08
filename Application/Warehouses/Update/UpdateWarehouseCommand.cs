using MediatR;

namespace Application.Warehouses.Update;

public record UpdateWarehouseCommand(UpdateWarehouseRequest Request) : IRequest;