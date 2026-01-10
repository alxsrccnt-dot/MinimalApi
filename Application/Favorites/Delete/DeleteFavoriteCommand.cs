using MediatR;

namespace Application.Favorites.Delete;

public record DeleteFavoriteCommand(DeleteFavoriteRequest Request) : IRequest;