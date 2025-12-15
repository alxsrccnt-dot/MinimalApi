namespace Domain.Entities.Orders;

public class PurchaseOrder : Order
{
	public ICollection<PurchaseOrderLine>? Lines { get; set; }
}
