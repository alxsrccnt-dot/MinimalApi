using Application.Documents;
using Carter;

namespace DeveloperTest.Endpoints;

public class DocumentsEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/documents")
			.RequireAuthorization();

		group.MapGet("", GetOrders)
			.WithName(nameof(GetOrders));

	}

	public static async Task<IResult> GetOrders(GetDocumentsRequest request)
	{
		return Results.Ok("Orders retrieved successfully.");
	}

	public static async Task<IResult> UpdateOrders(GetDocumentsRequest request)
	{
		return Results.Ok("Orders retrieved successfully.");
	}

	public static async Task<IResult> DeleteOrders(GetDocumentsRequest request)
	{
		return Results.Ok("Orders retrieved successfully.");
	}
}