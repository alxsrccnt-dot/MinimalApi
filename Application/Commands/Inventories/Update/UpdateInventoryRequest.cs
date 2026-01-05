using Application.Commands.Inventories.Common;

namespace Application.Commands.Inventories.Update;

public class UpdateInventoryRequest(int physicalProductId, int warehouseId, int quantity)
	: CreateOrUpdateInventoryRequest(physicalProductId, warehouseId, quantity);