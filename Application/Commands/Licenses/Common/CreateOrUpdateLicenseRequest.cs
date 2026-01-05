namespace Application.Commands.Licenses.Common;

public class CreateOrUpdateLicenseRequest(int licensedProductId, DateTime expirationDate)
{
	public int LicensedProductId { get; init; } = licensedProductId;
	public DateTime ExpirationDate { get; init; } = expirationDate;
}