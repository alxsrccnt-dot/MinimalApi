using MediatR;

namespace Application.Favorites.Create;

public record CreateFavoriteCommand(CreateFavoriteRequest Request) : IRequest;