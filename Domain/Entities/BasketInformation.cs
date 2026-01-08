using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class BasketInformation : BaseEntity<Guid>
{
	public int ProductId { get; set; }
	public int Quantity { get; set; }
	public string UserEmail { get; set; } = null!;
	public BasketItemStatus Status { get; set; }

	public Product Product { get; set; } = null!;
}