using MediatR;

namespace Application.BusinessPartners.Update;

public record UpdateBusinessPartnerCommand(UpdateBusinessPartnerRequest Request) : IRequest;