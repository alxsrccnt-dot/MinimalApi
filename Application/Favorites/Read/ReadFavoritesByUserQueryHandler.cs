using Application.Common.Services;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Favorites.Read;

public class ReadFavoritesByUserQueryHandler(ICurrentUser currentUser, IFavoriteReadRepository repository) : IRequestHandler<ReadFavoritesByUserQuery, IEnumerable<FavoriteCollectionDto>>
{
	public async Task<IEnumerable<FavoriteCollectionDto>> Handle(ReadFavoritesByUserQuery request, CancellationToken cancellationToken)
	{
		var userFavourites = await repository.GetUserFavouritesAsync(currentUser.Email!, cancellationToken);

		var favoritesCollection = new List<FavoriteDto>();
		return userFavourites.Select( uf => new FavoriteCollectionDto(uf));
	}
}