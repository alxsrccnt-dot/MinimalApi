using MediatR;

namespace Application.Favorites.Read;

public record ReadFavoritesByUserQuery() : IRequest<IEnumerable<FavoriteCollectionDto>>;