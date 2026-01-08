namespace Domain.Entities;

public class LicensedProduct(string code, string title, string description, int price, int categoryId) : Product(code, title, description, price, categoryId)
{
	public ICollection<License> Licenses { get; set; } = [];
	public ICollection<LicensedOrderLine> LicensedOrderLines { get; set; } = [];
}