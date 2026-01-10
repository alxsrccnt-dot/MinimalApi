using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities;

public class BasketInformation(string userEmail, int productId, int quantity) : BaseEntity<Guid>
{
	public string UserEmail { get; set; } = userEmail;
	public int ProductId { get; set; } = productId;
	public int Quantity { get; set; } = quantity;
	public BasketItemStatus Status { get; set; } = BasketItemStatus.Selected;

	public Product Product { get; set; } = null!;
}