namespace Domain.Entities;

public class PhysicalProduct(string code, string title, string description, int price, int categoryId) : Product(code, title, description, price, categoryId)
{
	public ICollection<PhysicalOrderline> PhysicalOrderlines { get; set; } = [];
	public ICollection<Inventory> Inventories { get; set; } = [];
}