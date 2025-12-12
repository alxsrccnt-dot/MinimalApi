using MediatR;

namespace Application.Authentification;

public record GetSecurityTokenCommand(AuthenticationRequest request) : IRequest<string> { }
