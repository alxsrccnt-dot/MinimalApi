using Application.Exceptions;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Authentification;

public class GetSecurityTokenCommandHandler(ApplicationDbContext context, ITokenService jwtService) : IRequestHandler<GetSecurityTokenCommand, string>
{
	public async Task<string> Handle(GetSecurityTokenCommand command, CancellationToken cancellationToken)
	{
		var user = await context.Users
			.AsNoTracking()
			.FirstOrDefaultAsync(u =>
				u.UserName == command.request.Username &&
				u.Password == command.request.Password &&
				u.Active);

		if (user == null) throw new NullReferenceException("Invalid username or password.");

		if (!user.Active) throw new InactiveUserException();

		return jwtService.GenerateJwtToken(user);
	}
}