using Domain.Entities.Base;

namespace Domain.Entities;

public class UserFavorite : BaseEntity<Guid>
{
	public string Title { get; set; } = null!;
	public string UserEmail { get; set; } = null!;

	public ICollection<FavoriteItem> FavoriteItems { get; set; } = [];
}