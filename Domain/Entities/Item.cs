using Domain.Entities.Orders;

namespace Domain.Entities;

public class Item
{
	public string ItemCode { get; set; } = null!;
	public string ItemName { get; set; } = null!;
	public bool Active { get; set; } = true;

	public ICollection<SaleOrderLine>? SaleOrderLines { get; set; }
	public ICollection<PurchaseOrderLine>? PurchaseOrderLines { get; set; }
}
