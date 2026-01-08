using Domain.Entities.Base;

namespace Domain.Entities;

public class Warehouse(string City) : Entity<int>
{
	public string City { get; set; } = City;

	public ICollection<Inventory> Inventories { get; set; } = [];
}