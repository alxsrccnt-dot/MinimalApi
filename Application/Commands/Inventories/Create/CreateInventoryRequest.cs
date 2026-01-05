using Application.Commands.Inventories.Common;

namespace Application.Commands.Inventories.Create;

public class CreateInventoryRequest(int physicalProductId, int warehouseId, int quantity)
	: CreateOrUpdateInventoryRequest(physicalProductId, warehouseId, quantity);