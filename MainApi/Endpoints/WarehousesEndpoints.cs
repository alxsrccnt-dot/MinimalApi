using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Application.Commands.Warehouses.Create;

namespace MainApi.Endpoints;

public class WarehousesEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var adminGroup = app.MapGroup("/api/admin/warehouses")
			.AllowAnonymous();

		adminGroup.MapPost("", AddWarehouse)
			.WithName(nameof(AddWarehouse));
	}

	public async Task<IResult> AddWarehouse([FromServices] IMediator mediator,
		[FromBody] CreateWarehouseRequest request)
	{
		await mediator.Send(new CreateWarehouseCommand(request));
		return Results.Ok("Warehouse added.");
	}
}