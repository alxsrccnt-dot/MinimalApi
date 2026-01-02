using Domain.Entities.Base;

namespace Domain.Entities.Product;

public class Warehouse : Entity<int>
{
	public string City { get; set; } = null!;

	public ICollection<Inventory> Inventories { get; set; } = [];
}