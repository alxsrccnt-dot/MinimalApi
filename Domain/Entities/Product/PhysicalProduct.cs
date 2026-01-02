using Domain.Entities.Orders;

namespace Domain.Entities.Product;

public class PhysicalProduct : Product
{
	public ICollection<PhysicalOrderline> PhysicalOrderlines { get; set; } = [];
	public ICollection<Inventory> Inventories { get; set; } = [];
}