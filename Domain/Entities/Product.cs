using Domain.Entities.Base;

namespace Domain.Entities;

public abstract class Product(string code, string title, string description, int price, int categoryId) : BaseEntity<int>
{
	public string Code { get; set; } = code;
	public string Title { get; set; } = title;
	public string Description { get; set; } = description;
	public decimal Price { get; set; } = price;
	public bool IsActive { get; set; }

	public int CategoryId { get; set; } = categoryId;
	public Category Category{ get; set; } = null!;

	public abstract bool IsAvailable();

	public ICollection<Rating> Ratings { get; set; } = null!;
	public ICollection<BasketInformation> BasketsInformation { get; set; } = [];
	public ICollection<FavoriteItem> FavoritesItem { get; set; } = [];
}