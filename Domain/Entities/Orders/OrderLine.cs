namespace Domain.Entities.Orders;

public abstract class OrderLine
{
	public int LineID { get; set; }
	public int DocID { get; set; }
	public string ItemCode { get; set; } = null!;
	public decimal Quantity { get; set; }
	public DateTime CreateDate { get; set; }
	public DateTime? LastUpdateDate { get; set; }
	public int CreatedBy { get; set; }
	public int? LastUpdatedBy { get; set; }

	public PurchaseOrder? PurchaseOrder { get; set; }
	public Item? Item { get; set; }
	public User? Creator { get; set; }
	public User? Updater { get; set; }
}
