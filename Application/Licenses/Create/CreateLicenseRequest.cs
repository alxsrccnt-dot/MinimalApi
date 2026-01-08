using Application.Licenses.Common;

namespace Application.Licenses.Create;

public class CreateLicenseRequest(int licensedProductId, DateTime expirationDate)
	: CreateOrUpdateLicenseRequest(licensedProductId, expirationDate);