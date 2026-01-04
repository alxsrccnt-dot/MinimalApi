using Application.Common;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.BusinessPartners.Read;

public class ReadIBusinessPartnersCommandHandler(ApplicationDbContext context) : IRequestHandler<ReadBusinessPartnersCommand, PaginatedResultDto<BusinessPartnerDto>>
{
	public async Task<PaginatedResultDto<BusinessPartnerDto>> Handle(ReadBusinessPartnersCommand command, CancellationToken cancellationToken)
	{
		var searchInfo = command.ReadBusinessPartnersRequest;
		var businessPartnersQuery = context.BusinessPartners.AsQueryable();

		var filterValue = searchInfo.FilterValue;
		businessPartnersQuery = filterValue is null && searchInfo.FilterByColumn is FilterByBusinessPartnersColumn.None
			? businessPartnersQuery
			: searchInfo.FilterByColumn switch
			{
				FilterByBusinessPartnersColumn.BPCode => businessPartnersQuery.Where(bp => bp.Code == filterValue),
				FilterByBusinessPartnersColumn.BPName => businessPartnersQuery.Where(bp => bp.Name == filterValue),
			};

		businessPartnersQuery = 
			businessPartnersQuery.OrderBy(i => i.Code)
			.Skip(searchInfo.PageSize * searchInfo.PageNumber)
			.Take(searchInfo.PageNumber);

		var totalCount = await businessPartnersQuery.CountAsync(cancellationToken);
		var businessPartnersDtos = await businessPartnersQuery
			.Select(businessPartner => new BusinessPartnerDto(businessPartner.Code, businessPartner.Name))
			.ToListAsync(cancellationToken);

		return new PaginatedResultDto<BusinessPartnerDto>
		{
			Data = businessPartnersDtos,
			TotalCount = totalCount,
			PageNumber = searchInfo.PageNumber,
			PageSize = searchInfo.PageSize,
			TotalPages = (int)Math.Ceiling(totalCount / (double)searchInfo.PageSize)
		};
	}
}