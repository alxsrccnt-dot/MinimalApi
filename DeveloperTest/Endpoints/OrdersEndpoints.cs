using Application.Orders.Create;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Endpoints;

public class OrdersEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/documents")
			.RequireAuthorization();

		group.MapGet("", GetOrders)
			.WithName(nameof(GetOrders));

		group.MapPost("", CreateOrders)
			.WithName(nameof(CreateOrders));

		group.MapPut("", UpdateOrders)
			.WithName(nameof(UpdateOrders));

		group.MapDelete("", DeleteOrders)
			.WithName(nameof(DeleteOrders));
	}

	public async Task<IResult> GetOrders()
	{
		return Results.Ok("Orders retrieved successfully.");
	}

	public async Task<IResult> CreateOrders([FromServices] IMediator mediator, [FromBody]CreateOrderRequest request)
		=> await mediator.Send(new CreateOrderCommand(request))
			.ContinueWith(_ => Results.Ok("Order created successfully."));

	public async Task<IResult> UpdateOrders()
	{
		return Results.Ok("Orders retrieved successfully.");
	}

	public async Task<IResult> DeleteOrders(int id, [FromServices] IMediator mediator)
	{
		return Results.Ok("Orders retrieved successfully.");
	}
}