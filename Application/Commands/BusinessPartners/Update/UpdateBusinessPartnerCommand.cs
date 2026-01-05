using MediatR;

namespace Application.Commands.BusinessPartners.Update;

public record UpdateBusinessPartnerCommand(UpdateBusinessPartnerRequest Request) : IRequest;