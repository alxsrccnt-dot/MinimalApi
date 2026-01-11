using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Favorites.Create;
using Application.Favorites.Delete;
using Application.Favorites.Read;

namespace MainApi.Endpoints;

public class FavoritesEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/favorites")
			.RequireAuthorization();

		group.MapGet("", GetUserFavoritesCollection)
			.WithName(nameof(GetUserFavoritesCollection));

		group.MapPost("", AddFavoriteWithCollection)
			.WithName(nameof(AddFavoriteWithCollection));

		group.MapPost("", AddFavorite)
			.WithName(nameof(AddFavorite));

		group.MapDelete("", RemoveFavorite)
			.WithName(nameof(RemoveFavorite));
	}

	public async Task<IResult> GetUserFavoritesCollection([FromServices] IMediator mediator)
	{
		var items = await mediator.Send(new ReadFavoritesByUserQuery());
		return Results.Ok(items);
	}

	public async Task<IResult> AddFavorite([FromServices] IMediator mediator, [FromBody] CreateFavoriteRequest request)
	{
		await mediator.Send(new CreateFavoriteCommand(request));
		return Results.Ok("Favorite added.");
	}

	public async Task<IResult> AddFavoriteWithCollection([FromServices] IMediator mediator, [FromBody] CreateFavoriteWithCollectionCommand request)
	{
		await mediator.Send(new CreateFavoriteWithCollectionCommand(request));
		return Results.Ok("Favorite added.");
	}

	public async Task<IResult> RemoveFavorite([FromServices] IMediator mediator, [FromBody] DeleteFavoriteRequest request)
	{
		await mediator.Send(new DeleteFavoriteCommand(request));
		return Results.Ok("Favorite removed.");
	}
}