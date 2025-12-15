namespace Domain.Entities.Orders;

public class SaleOrder : Order
{
	public ICollection<SaleOrderLine>? Lines { get; set; }
	public ICollection<SaleOrderLineComment>? Comments { get; set; }
}