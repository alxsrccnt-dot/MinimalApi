using Domain.Entities.Base;

namespace Domain.Entities.Product;

public abstract class Product : Entity<int>
{
	//make code unique
	public string Code { get; set; } = null!;
	public string Title { get; set; } = null!;
	public string Description { get; set; } = null!;
	public int Price { get; set; }
	public bool IsActive { get; set; }

	public ICollection<Rating> Ratings { get; set; } = null!;
}