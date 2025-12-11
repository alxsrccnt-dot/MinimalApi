namespace Domain.Entities.Orders;

public class SaleOrderLineComment
{
	public int CommentLineID { get; set; }
	public int DocID { get; set; }
	public int LineID { get; set; }
	public string Comment { get; set; } = null!;

	public SaleOrder? SaleOrder { get; set; }
	public SaleOrderLine? Line { get; set; }
}