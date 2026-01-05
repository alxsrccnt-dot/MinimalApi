using MediatR;

namespace Application.Commands.BusinessPartners.Create;

public record CreateBusinessPartnerCommand(CreateBusinessPartnerRequest Request) : IRequest;