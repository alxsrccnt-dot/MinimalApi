using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Warehouses.Create;
using Application.Warehouses.Update;

namespace MainApi.Endpoints;

public class WarehousesEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var adminGroup = app.MapGroup("/api/admin/warehouses")
			.RequireAuthorization("admins.manage");

		adminGroup.MapPost("", AddWarehouse)
			.WithName(nameof(AddWarehouse));

		adminGroup.MapPut("", UpdateWarehouse)
			.WithName(nameof(UpdateWarehouse));
	}

	public async Task<IResult> AddWarehouse([FromServices] IMediator mediator,
		[FromBody] CreateWarehouseRequest request)
	{
		await mediator.Send(new CreateWarehouseCommand(request));
		return Results.Ok("Warehouse added.");
	}

	public async Task<IResult> UpdateWarehouse([FromServices] IMediator mediator,
		[FromBody] UpdateWarehouseRequest request)
	{
		await mediator.Send(new UpdateWarehouseCommand(request));
		return Results.Ok("Warehouse updated.");
	}
}