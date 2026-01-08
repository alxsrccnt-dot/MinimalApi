using MediatR;

namespace Application.BusinessPartners.Create;

public record CreateBusinessPartnerCommand(CreateBusinessPartnerRequest Request) : IRequest;