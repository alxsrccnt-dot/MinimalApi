using Application.Warehouses.Common;

namespace Application.Warehouses.Create;

public class CreateWarehouseRequest(string city) : CreateOrUpdateWarehouseRequest(city);