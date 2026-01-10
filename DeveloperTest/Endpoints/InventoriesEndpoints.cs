using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Inventories.Create;
using Application.Inventories.Update;

namespace MainApi.Endpoints;

public class InventoriesEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var adminGroup = app.MapGroup("/api/admin/inventories")
			.RequireAuthorization("admins.manage");

		adminGroup.MapPost("", AddInventory)
			.WithName(nameof(AddInventory));

		adminGroup.MapPut("", UpdateInventory)
			.WithName(nameof(UpdateInventory));
	}

	public async Task<IResult> AddInventory([FromServices] IMediator mediator,
		[FromBody] CreateInventoryRequest request)
	{
		await mediator.Send(new CreateInventoryCommand(request));
		return Results.Ok("Inventory added.");
	}

	public async Task<IResult> UpdateInventory([FromServices] IMediator mediator,
		[FromBody] UpdateInventoryRequest request)
	{
		await mediator.Send(new UpdateInventoryCommand(request));
		return Results.Ok("Inventory updated.");
	}
}