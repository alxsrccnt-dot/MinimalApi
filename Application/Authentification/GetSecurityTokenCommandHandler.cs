using Application.Services;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Authentification;

public class GetSecurityTokenCommandHandler(ApplicationDbContext context, IJwtService jwtService) : IRequestHandler<GetSecurityTokenCommand, string>
{
	public async Task<string> Handle(GetSecurityTokenCommand command, CancellationToken cancellationToken)
	{
		var user = await context.Users
			.FirstOrDefaultAsync(u =>
				u.UserName == command.request.Username &&
				u.Password == command.request.Password &&
				u.Active);

		if (user == null) throw new ArgumentNullException("Invalid username or password.");

		return jwtService.GenerateJwtToken(user);
	}
}
