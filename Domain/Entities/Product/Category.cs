using Domain.Entities.Base;

namespace Domain.Entities.Product;

public class Category(string title) : BaseEntity<int>
{
	public string Title { get; set; } = title;
	public bool IsActive { get; set; }
	public ICollection<Product> Products { get; set; } = [];
}