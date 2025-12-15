namespace Domain.Entities.Orders;

public class SaleOrderLine : OrderLine
{
	public SaleOrder? SaleOrder { get; set; }
	public ICollection<SaleOrderLineComment>? Comments { get; set; }
}