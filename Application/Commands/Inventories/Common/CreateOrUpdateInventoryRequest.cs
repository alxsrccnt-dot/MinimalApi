namespace Application.Commands.Inventories.Common;

public class CreateOrUpdateInventoryRequest(int physicalProductId, int warehouseId, int quantity)
{
	public int PhysicalProductId { get; init; } = physicalProductId;
	public int WarehouseId { get; init; } = warehouseId;
	public int Quantity { get; init; } = quantity;
}