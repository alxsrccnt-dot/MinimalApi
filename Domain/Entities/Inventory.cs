namespace Domain.Entities;

public class Inventory
{
	public int PhysicalProductId { get; set; }
	public PhysicalProduct PhysicalProduct { get; set; }

	public int WarehouseId { get; set; }
	public Warehouse Warehouse { get; set; }

	public int Quantity { get; set; }
}
/*
 * Get all warehouses for a product
var product = context.PhysicalProducts
    .Include(p => p.Inventories)
        .ThenInclude(i => i.Warehouse)
    .First(p => p.Id == productId);

 * Get stock per warehouse
var stock = context.Inventories
    .Where(i => i.PhysicalProductId == productId)
    .Select(i => new
    {
        i.Warehouse.City,
        i.Quantity
    })
    .ToList();

 * Total quantity across warehouses
var total = context.Inventories
    .Where(i => i.PhysicalProductId == productId)
    .Sum(i => i.Quantity);
*/