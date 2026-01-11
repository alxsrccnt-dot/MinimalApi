using Domain.Entities;

namespace Application.Favorites.Read;

public class FavoriteDto(FavoriteItem favoriteItem)
{
	public int Id{ get; set; } = favoriteItem.ProductId;
	public string Title{ get; set; } = favoriteItem.Product.Title;
}