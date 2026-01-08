using Application.Inventories.Common;

namespace Application.Inventories.Create;

public class CreateInventoryRequest(int physicalProductId, int warehouseId, int quantity)
	: CreateOrUpdateInventoryRequest(physicalProductId, warehouseId, quantity);