using Application.BusinessPartners.Common;

namespace Application.BusinessPartners.Update;

public class UpdateBusinessPartnerRequest(int id, string code, string name)
	: CreateOrUpdateBusinessPartnerRequest(code, name)
{
	public int Id { get; init; } = id;
}