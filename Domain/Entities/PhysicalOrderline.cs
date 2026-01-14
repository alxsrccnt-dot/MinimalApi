namespace Domain.Entities;

public class  PhysicalOrderline : OrderLine
{
	public int Quantity { get; set; }
	public int PhysicalProductId { get; set; }
	public PhysicalProduct PhysicalProduct { get; set; } = null!;

	public override decimal GetTotalPrice() => PhysicalProduct.Price * Quantity;
}