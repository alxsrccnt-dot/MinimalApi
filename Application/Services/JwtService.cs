using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services;

public class JwtService(string key, string issuer, string audience) : IJwtService
{
	public string GenerateJwtToken(User user)
	{
		var tkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
		var creds = new SigningCredentials(tkey, SecurityAlgorithms.HmacSha256);

		var claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
			new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
		};

		var token = new JwtSecurityToken(
			issuer: issuer,
			audience: audience,
			claims: claims,
			expires: DateTime.UtcNow.AddHours(1),
			signingCredentials: creds);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
