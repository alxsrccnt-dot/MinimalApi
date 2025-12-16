using Application.BusinessPartners.Read;
using Application.Common;
using Carter;
using MediatR;

namespace DeveloperTest.Endpoints;

public class BusinessPartnersEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/business-partners");
		//.RequireAuthorization();

		group.MapGet("", GetBusinessPartners)
			.WithName(nameof(GetBusinessPartners));
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
}