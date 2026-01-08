using Application.Licenses.Common;

namespace Application.Licenses.Update;

public class UpdateLicenseRequest
	(Guid Id, int licensedProductId, DateTime expirationDate)
	: CreateOrUpdateLicenseRequest(licensedProductId, expirationDate)
{
	public Guid Id { get; init; } = Id;
}