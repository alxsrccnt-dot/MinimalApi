using Domain.Entities.Base;

namespace Domain.Entities;

public class FavoriteItem : Entity<Guid>
{
	public int ProductId { get; set; }
	public Guid UserFavoriteId { get; set; }

	public UserFavorite UserFavorite { get; set; } = null!;
	public Product Product { get; set; } = null!;
}
