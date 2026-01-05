using Application.Commands.BusinessPartners.Common;

namespace Application.Commands.BusinessPartners.Update;

public class UpdateBusinessPartnerRequest(int id, string code, string name)
	: CreateOrUpdateBusinessPartnerRequest(code, name)
{
	public int Id { get; init; } = id;
}