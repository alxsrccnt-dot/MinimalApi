using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Application.Favorites.Delete;

public class DeleteFavoriteCommandHandler() : IRequestHandler<DeleteFavoriteCommand>
{
	public async Task Handle(DeleteFavoriteCommand command, CancellationToken cancellationToken)
	{
		//var r = command.Request;

		//var userFav = await context.UserFavorites
		//	.Include(u => u.Items)
		//	.FirstOrDefaultAsync(u => u.UserEmail == r.UserEmail, cancellationToken);

		//if (userFav is null)
		//	throw new ValidationException("User favorites not found.");

		//var item = userFav.Items.FirstOrDefault(i => i.ProductId == r.ProductId);
		//if (item is null)
		//	throw new ValidationException("Favorite item not found.");

		//context.FavoriteItems.Remove(item);
		//await context.SaveChangesAsync(cancellationToken);
	}
}