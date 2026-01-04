using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities.Product;

public class Rating : BaseEntity<int>
{
	public RaitingScoreValues Score { get; set; }
	public string Comment { get; set; } = null!;
	public int ProductId { get; set; }
	public Product Product { get; set; } = null!;
}