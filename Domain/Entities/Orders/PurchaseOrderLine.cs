namespace Domain.Entities.Orders;

public class PurchaseOrderLine : OrderLine
{
	public PurchaseOrder? PurchaseOrder { get; set; }
}