using Application.Documents;
using Carter;

namespace DeveloperTest.Endpoints;

public class DocumentsEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/documents");
		//.RequireAuthorization();

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

	public async Task<IResult> CreateOrders()
	{
		return Results.Ok("Orders retrieved successfully.");
	}

	public async Task<IResult> UpdateOrders()
	{
		return Results.Ok("Orders retrieved successfully.");
	}

	public async Task<IResult> DeleteOrders()
	{
		return Results.Ok("Orders retrieved successfully.");
	}
}