using Domain.Entities.Base;

namespace Domain.Entities.Orders;

public abstract class Order : BaseEntity
{
	public string BPCode { get; set; } = null!;
	public DateTime CreateDate { get; set; }
	public DateTime? LastUpdateDate { get; set; }
	public int CreatedBy { get; set; }
	public int? LastUpdatedBy { get; set; }

	public BusinessPartner? BusinessPartner { get; set; }
	public User? Creator { get; set; }
	public User? Updater { get; set; }
}