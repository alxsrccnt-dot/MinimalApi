using Domain.Entities.Base;

namespace Domain.Entities.Orders;

public class OrderComment : BaseEntity<int>
{
	public string Comment { get; set; } = null!;
	public int OrderID { get; set; }
	public Order? Order { get; set; }
}