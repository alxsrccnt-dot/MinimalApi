using MediatR;

namespace Application.Favorites.Create;

public record CreateFavoriteWithCollectionCommand(CreateFavoritewithCollectionRequest Request) : IRequest;