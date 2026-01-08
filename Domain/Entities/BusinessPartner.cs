using Domain.Entities.Base;

namespace Domain.Entities;

public class BusinessPartner : Entity<int>
{
	public string Code { get; set; } = null!;
	public string Name { get; set; } = null!;

	public ICollection<Order>? Orders { get; set; }
}