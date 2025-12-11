using Domain.Entities.Base;
using Domain.Entities.Orders;

namespace Domain.Entities;

public class User : BaseEntity
{
	public string FullName { get; set; } = null!;
	public string UserName { get; set; } = null!;
	public string Password { get; set; } = null!;
	public bool Active { get; set; } = true;

	public ICollection<SaleOrder>? CreatedSaleOrders { get; set; }
	public ICollection<SaleOrder>? UpdatedSaleOrders { get; set; }
	public ICollection<SaleOrderLine>? CreatedSaleOrderLines { get; set; }
	public ICollection<SaleOrderLine>? UpdatedSaleOrderLines { get; set; }
	public ICollection<PurchaseOrder>? CreatedPurchaseOrders { get; set; }
	public ICollection<PurchaseOrder>? UpdatedPurchaseOrders { get; set; }
	public ICollection<PurchaseOrderLine>? CreatedPurchaseOrderLines { get; set; }
	public ICollection<PurchaseOrderLine>? UpdatedPurchaseOrderLines { get; set; }
}
