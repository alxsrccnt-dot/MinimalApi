using Application.Users.Authentification;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DeveloperTest;

public static class DependencyInjection
{
	public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration config)
	{
		var tokenSettings = config.GetSection("TokenSettings").Get<TokenSettings>();
		AddCustomAuthentification(services, tokenSettings);

		return services;
	}

	private static void AddCustomAuthentification(this IServiceCollection services, TokenSettings tokenSettings)
	{
		services.AddAuthentication("Bearer")
			.AddJwtBearer("Bearer", options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = tokenSettings.Issuer,
					ValidAudience = tokenSettings.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(tokenSettings.Secret!)
					)
				};
			});
	}
}