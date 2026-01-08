using Domain.Entities.Base;

namespace Domain.Entities;

public class Order : BaseEntity<int>
{
	public int BusinessPartnerId { get; set; }
	public BusinessPartner? BusinessPartner { get; set; }
	
	public decimal TotalAmount { get; set; } 
	
	public ICollection<OrderLine>? OrderLines { get; set; } = [];
	public OrderComment? Comment { get; set; }

	public void SetTotalAmount() => TotalAmount = OrderLines?.Sum(ol => ol.GetTotalPrice()) ?? 0;
}