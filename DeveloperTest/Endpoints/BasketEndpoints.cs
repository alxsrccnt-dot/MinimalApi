using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Basket.Create;
using Application.Basket.Update;
using Application.Basket.Read;

namespace MainApi.Endpoints;

public class BasketEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/basket")
			.RequireAuthorization();

		group.MapGet("", GetBasketForUser)
			.WithName(nameof(GetBasketForUser));

		group.MapPost("", AddToBasket)
			.WithName(nameof(AddToBasket));

		group.MapPut("", UpdateBasket)
			.WithName(nameof(UpdateBasket));
	}

	public async Task<IResult> GetBasketForUser([FromServices] IMediator mediator)
		=> Results.Ok(await mediator.Send(new GetBasketByUserQuery()));

	public async Task<IResult> AddToBasket([FromServices] IMediator mediator, [FromBody] CreateBasketItemRequest request)
	{
		await mediator.Send(new CreateBasketItemCommand(request));
		return Results.Ok("Added to basket.");
	}

	public async Task<IResult> UpdateBasket([FromServices] IMediator mediator, [FromBody] UpdateBasketItemRequest request)
	{
		await mediator.Send(new UpdateBasketItemCommand(request));
		return Results.Ok("Basket updated.");
	}
}