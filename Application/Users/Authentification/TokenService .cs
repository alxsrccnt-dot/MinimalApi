using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Users.Authentification;

public class TokenService(TokenSettings jwtSettings) : ITokenService
{
	public string GenerateJwtToken(User user)
	{
		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
			new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
		};

		var token = new JwtSecurityToken(
			issuer: jwtSettings.Issuer,
			audience: jwtSettings.Audience,
			claims: claims,
			expires: DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationInMinutes),
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
