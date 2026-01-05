using Application.Commands.Warehouses.Common;

namespace Application.Commands.Warehouses.Update;

public class UpdateWarehouseRequest(int id, string city) : CreateOrUpdateWarehouseRequest(city)
{
	public int Id { get; init; } = id;
}