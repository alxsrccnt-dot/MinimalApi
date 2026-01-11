using Domain.Entities;

namespace Application.Favorites.Read;

public class FavoriteCollectionDto(UserFavorite userFavorite)
{
	public string Title { get; set; } = userFavorite.Title;
	public List<FavoriteDto> Favorites { get; set; } = userFavorite.FavoriteItems.Select(i => new FavoriteDto(i)).ToList();
}