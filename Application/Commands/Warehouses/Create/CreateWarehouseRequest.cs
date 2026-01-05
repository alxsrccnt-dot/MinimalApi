using Application.Commands.Warehouses.Common;

namespace Application.Commands.Warehouses.Create;

public class CreateWarehouseRequest(string city) : CreateOrUpdateWarehouseRequest(city);