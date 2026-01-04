using Application.Common;
using MediatR;

namespace Application.Queries.BusinessPartners.Read;

public record ReadBusinessPartnersCommand(
	PaginatedRequest<FilterByBusinessPartnersColumn> ReadBusinessPartnersRequest)
	: IRequest<PaginatedResultDto<BusinessPartnerDto>>;