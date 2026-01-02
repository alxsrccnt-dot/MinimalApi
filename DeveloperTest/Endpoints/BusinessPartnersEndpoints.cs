using Application.BusinessPartners.Read;
using Application.Common;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MainApi.Endpoints;

public class BusinessPartnersEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/business-partners")
			.RequireAuthorization();

		group.MapGet("", GetBusinessPartners)
			.WithName(nameof(GetBusinessPartners));

		group.MapPost("", AddBusinessPartners)
			.WithName(nameof(AddBusinessPartners));

		group.MapPut("", UpdateBusinessPartners)
			.WithName(nameof(UpdateBusinessPartners));
	}

	public async Task<IResult> GetBusinessPartners(IMediator mediator,
			FilterByBusinessPartnersColumn? filterByColumn,
			string? filterValue,
			int pageNumber = 1,
			int pageSize = 10)
	{
		var readBusinessPartnerRequest = new PaginatedRequest<FilterByBusinessPartnersColumn>
		{
			FilterByColumn = filterByColumn is not null ? filterByColumn.Value : FilterByBusinessPartnersColumn.None,
			FilterValue = filterValue,
			PageNumber = pageNumber,
			PageSize = pageSize
		};
		var paginedDto = await mediator.Send(new ReadBusinessPartnersCommand(readBusinessPartnerRequest));

		if (paginedDto.IsEmpty())
			return Results.NotFound("No business partner found.");

		return Results.Ok(paginedDto);
	}

	public async Task<IResult> AddBusinessPartners(IMediator mediator)
	{
		return Results.Ok("New bussines partener added.");
	}

	public async Task<IResult> UpdateBusinessPartners(IMediator mediator)
	{
		return Results.Ok("Bussines partener updated.");
	}
}