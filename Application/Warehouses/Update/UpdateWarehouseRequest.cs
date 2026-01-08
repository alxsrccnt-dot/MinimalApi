using Application.Warehouses.Common;

namespace Application.Warehouses.Update;

public class UpdateWarehouseRequest(int id, string city) : CreateOrUpdateWarehouseRequest(city)
{
	public int Id { get; init; } = id;
}