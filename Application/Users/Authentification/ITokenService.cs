using Domain.Entities;

namespace Application.Users.Authentification;

public interface ITokenService
{
	string GenerateJwtToken(User user);
}
