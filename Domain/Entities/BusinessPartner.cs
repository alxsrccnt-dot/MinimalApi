using Domain.Entities.Orders;

namespace Domain.Entities;

public class BusinessPartner
{
	public string BPCode { get; set; } = null!;
	public string BPName { get; set; } = null!;
	public string BPType { get; set; } = null!;
	public bool Active { get; set; } = true;

	public BPType Type { get; set; } = null!;
	public ICollection<SaleOrder>? SaleOrders { get; set; }
	public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
}