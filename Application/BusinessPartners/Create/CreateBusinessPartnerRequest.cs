using Application.BusinessPartners.Common;

namespace Application.BusinessPartners.Create;

public class CreateBusinessPartnerRequest(string code, string name)
	: CreateOrUpdateBusinessPartnerRequest(code, name);