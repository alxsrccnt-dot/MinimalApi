using Application.Commands.Licenses.Common;

namespace Application.Commands.Licenses.Create;

public class CreateLicenseRequest(int licensedProductId, DateTime expirationDate)
	: CreateOrUpdateLicenseRequest(licensedProductId, expirationDate);