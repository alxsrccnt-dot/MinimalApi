using Application.Inventories.Common;

namespace Application.Inventories.Update;

public class UpdateInventoryRequest(int physicalProductId, int warehouseId, int quantity)
	: CreateOrUpdateInventoryRequest(physicalProductId, warehouseId, quantity);