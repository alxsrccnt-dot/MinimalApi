using Application.Common.Services;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Favorites.Read;

public class ReadFavoritesByUserHandler(ICurrentUser currentUser, IFavoriteReadRepository repository) : IRequestHandler<ReadFavoritesByUserQuery, FavoriteCollectionDto>
{
	public async Task<FavoriteCollectionDto> Handle(ReadFavoritesByUserQuery request, CancellationToken cancellationToken)
	{
		var userEmail = currentUser.Email;
		var userFavourites = await repository.GetUserFavouritesAsync(userEmail!, cancellationToken);

		var favoritesCollection = new List<FavoriteDto>();
		return null;
		//var items = await context.FavoriteItems
		//	.AsNoTracking()
		//	.Where(fi => fi.UserFavorite.UserEmail == request.UserEmail)
		//	.Select(fi => new FavoriteDto(fi.ProductId))
		//	.ToListAsync(cancellationToken);

		//return items;
	}
}