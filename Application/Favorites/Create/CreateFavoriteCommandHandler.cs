using Application.Common.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Favorites.Create;

public class CreateFavoriteCommandHandler(ICreateRepository<FavoriteItem> createRepository) : IRequestHandler<CreateFavoriteCommand>
{
	public async Task Handle(CreateFavoriteCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;

		var favoriteItem = new FavoriteItem
		{
			ProductId = request.ProductId,
			UserFavoriteId = request.CollectionId
		};

		await createRepository.CreateAsync(favoriteItem, cancellationToken);
	}
}