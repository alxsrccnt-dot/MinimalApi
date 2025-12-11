namespace Domain.Entities;

public class BPType
{
	public string TypeCode { get; set; } = null!;
	public string TypeName { get; set; } = null!;

	public ICollection<BusinessPartner>? BusinessPartners { get; set; }
}