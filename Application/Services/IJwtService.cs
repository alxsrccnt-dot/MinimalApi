using Domain.Entities;

namespace Application.Services;

public interface IJwtService
{
	string GenerateJwtToken(User user);
}
