using Domain.Entities.Base;

namespace Domain.Entities.Product;

public class License : Entity<Guid>
{
	public License(int licensedProductId, DateTime expirationDate)
	{
		Id = Guid.NewGuid();
		ExpirationDate = expirationDate;
		Key = generateKey(Id);
		LicensedProductId = licensedProductId;
	}

	public string Key { get; set; }
	public DateTime ExpirationDate { get; set; }
	public int LicensedProductId { get; set; }
	public LicensedProduct LicensedProduct { get; set; } = null!;

	private static string generateKey(Guid id)
		=> Convert.ToBase64String(id.ToByteArray())
			.Replace("+", "-")
			.Replace("/", "_")
			.TrimEnd('=');
}