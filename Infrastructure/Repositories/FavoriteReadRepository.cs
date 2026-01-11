using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class FavoriteReadRepository(ApplicationDbContext context) : IFavoriteReadRepository
{
	public async Task<IEnumerable<UserFavorite>> GetUserFavouritesAsync(string userEmail, CancellationToken cancellationToken = default)
		=> await context.UserFavorites
			.Include(uf => uf.FavoriteItems)
			.ThenInclude(fi => fi.Product).Take(5)
			.AsNoTracking()
			.Where(uf => uf.UserEmail == userEmail)
			.ToListAsync(cancellationToken);

	public async Task<UserFavorite?> GetUserFavouritesAsync(Guid UserFavoriteId, CancellationToken cancellationToken = default)
		=> await context.UserFavorites
			.Include(uf => uf.FavoriteItems)
			.ThenInclude(fi => fi.Product)
			.AsNoTracking()
			.Where(uf => uf.Id == UserFavoriteId)
			.FirstOrDefaultAsync(cancellationToken);
}