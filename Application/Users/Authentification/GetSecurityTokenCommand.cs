using MediatR;

namespace Application.Users.Authentification;

public record GetSecurityTokenCommand(AuthenticationRequest request) : IRequest<string> { }
