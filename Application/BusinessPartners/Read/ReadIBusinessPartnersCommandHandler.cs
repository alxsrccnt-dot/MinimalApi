using Application.Common;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.BusinessPartners.Read;

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
				FilterByBusinessPartnersColumn.BPCode => businessPartnersQuery.Where(bp => bp.BPCode == filterValue),
				FilterByBusinessPartnersColumn.BPName => businessPartnersQuery.Where(bp => bp.BPName == filterValue),
				FilterByBusinessPartnersColumn.BPType => businessPartnersQuery.Where(bp => bp.BPType == filterValue),
				FilterByBusinessPartnersColumn.Active => businessPartnersQuery.Where(bp => bp.Active) //to do
			};

		businessPartnersQuery = 
			businessPartnersQuery.OrderBy(i => i.BPCode)
			.Skip(searchInfo.PageSize * searchInfo.PageNumber)
			.Take(searchInfo.PageNumber);

		var totalCount = await businessPartnersQuery.CountAsync(cancellationToken);
		var businessPartnersDtos = await businessPartnersQuery
			.Select(businessPartner => new BusinessPartnerDto(businessPartner.BPCode, businessPartner.BPName, businessPartner.BPType, businessPartner.Active))
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