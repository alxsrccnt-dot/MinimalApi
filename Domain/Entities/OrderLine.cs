using Domain.Entities.Base;

namespace Domain.Entities;

public abstract class OrderLine : BaseEntity<int>
{ 
	public int OrderID { get; set; }
	public Order Order { get; set; }

	public abstract decimal GetTotalPrice();
}