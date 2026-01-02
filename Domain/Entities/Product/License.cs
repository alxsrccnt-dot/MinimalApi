using Domain.Entities.Base;

namespace Domain.Entities.Product;

public class License(DateTime ExpirationDate) : Entity<Guid>
{
	public string Key { get; set; } = generateKey();
	public DateTime ExpirationDate { get; set; } = ExpirationDate;
	public int LicensedProductId { get; set; }
	public LicensedProduct LicensedProduct { get; set; } = null!;

	private static string generateKey()
		=> Convert.ToBase64String(Guid.NewGuid().ToByteArray())
			.Replace("+", "-")
			.Replace("/", "_")
			.TrimEnd('=');
}