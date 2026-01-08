namespace Domain.Entities;

public class LicensedOrderLine : OrderLine
{
	public int LicensedProductID { get; set; }
	public LicensedProduct LicensedProduct { get; set; } = null!;

	public override decimal GetTotalPrice() => LicensedProduct.Price;
}