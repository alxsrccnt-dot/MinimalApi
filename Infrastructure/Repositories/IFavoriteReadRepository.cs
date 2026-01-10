using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IFavoriteReadRepository
{
	Task<IEnumerable<UserFavorite>> GetUserFavouritesAsync(string userEmail, CancellationToken cancellationToken = default);
	Task<UserFavorite?> GetUserFavouritesAsync(Guid UserFavoriteId, CancellationToken cancellationToken = default);
}