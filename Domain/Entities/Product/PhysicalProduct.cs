using Domain.Entities.Orders;

namespace Domain.Entities.Product;

public class PhysicalProduct(string code, string title, string description, int price, int categoryId) : Product(code, title, description, price, categoryId)
{
	public ICollection<PhysicalOrderline> PhysicalOrderlines { get; set; } = [];
	public ICollection<Inventory> Inventories { get; set; } = [];
}