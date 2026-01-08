using Application.Common;
using MediatR;

namespace Application.BusinessPartners.Read;

public record ReadBusinessPartnersCommand(
	PaginatedRequest<FilterByBusinessPartnersColumn> ReadBusinessPartnersRequest)
	: IRequest<PaginatedResultDto<BusinessPartnerDto>>;