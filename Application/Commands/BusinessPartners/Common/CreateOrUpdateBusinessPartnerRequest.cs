namespace Application.Commands.BusinessPartners.Common;

public class CreateOrUpdateBusinessPartnerRequest(string code, string name)
{
	public string Code { get; init; } = code;
	public string Name { get; init; } = name;
}