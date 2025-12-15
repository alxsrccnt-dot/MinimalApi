using Application.Users.Authentification;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
	{
		services.AddTransient<ITokenService, TokenService>(sp =>
		{
			var jwtSettings = config.GetSection("TokenSettings").Get<TokenSettings>();
			return new TokenService(jwtSettings);
		});

		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		return services;
	}
}
