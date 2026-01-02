using Domain.Entities.Orders;

namespace Domain.Entities.Product;

public class LicensedProduct : Product
{
	public ICollection<License> Licenses { get; set; } = [];
	public ICollection<LicensedOrderLine> LicensedOrderLines { get; set; } = [];
}