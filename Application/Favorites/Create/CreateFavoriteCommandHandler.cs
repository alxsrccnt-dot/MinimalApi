using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Favorites.Create;

public class CreateFavoriteCommandHandler() : IRequestHandler<CreateFavoriteCommand>
{
	public async Task Handle(CreateFavoriteCommand command, CancellationToken cancellationToken)
	{
		//var r = command.Request;

		//if (string.IsNullOrWhiteSpace(r.UserEmail))
		//	throw new ValidationException("UserEmail is required.");

		//// Find or create UserFavorite
		//var userFav = await context.UserFavorites
		//	.Include(u => u.Items)
		//	.FirstOrDefaultAsync(u => u.UserEmail == r.UserEmail, cancellationToken);

		//if (userFav is null)
		//{
		//	userFav = new UserFavorite
		//	{
		//		Id = Guid.NewGuid(),
		//		UserEmail = r.UserEmail
		//	};
		//	await context.UserFavorites.AddAsync(userFav, cancellationToken);
		//}

		//// Avoid duplicate favorite for same product
		//var exists = userFav.Items.Any(i => i.ProductId == r.ProductId);
		//if (!exists)
		//{
		//	var item = new FavoriteItem
		//	{
		//		Id = Guid.NewGuid(),
		//		ProductId = r.ProductId,
		//		UserFavoriteId = userFav.Id
		//	};
		//	await context.FavoriteItems.AddAsync(item, cancellationToken);
		//}

		//await context.SaveChangesAsync(cancellationToken);
	}
}