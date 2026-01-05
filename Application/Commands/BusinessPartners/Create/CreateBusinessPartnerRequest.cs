using Application.Commands.BusinessPartners.Common;

namespace Application.Commands.BusinessPartners.Create;

public class CreateBusinessPartnerRequest(string code, string name)
	: CreateOrUpdateBusinessPartnerRequest(code, name);