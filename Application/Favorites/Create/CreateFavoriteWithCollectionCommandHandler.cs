using Application.Common.Services;
using Domain.Entities;
using Infrastructure.Repositories;
using MediatR;

namespace Application.Favorites.Create;

public class CreateFavoriteWithCollectionCommandHandler(ICurrentUser currentUser, ICreateRepository<UserFavorite> createRepository) : IRequestHandler<CreateFavoriteWithCollectionCommand>
{
	public async Task Handle(CreateFavoriteWithCollectionCommand command, CancellationToken cancellationToken)
	{
		var request = command.Request;
		var FavoriteItem = new FavoriteItem
		{
			ProductId = request.ProductId,
		};
		var userFavorite = new UserFavorite
		{
			Title = request.Title,
			UserEmail = currentUser.Email!,
			FavoriteItems = { FavoriteItem }
		};

		await createRepository.CreateAsync(userFavorite, cancellationToken);
	}
}