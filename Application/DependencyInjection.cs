using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
	{
		services.AddTransient<IJwtService, JwtService>(sp =>
		{
			string key = config["JwtSettings:Key"] ?? throw new ArgumentNullException("JwtSettings:Key");
			string issuer = config["JwtSettings:Issuer"] ?? throw new ArgumentNullException("JwtSettings:Issuer");
			string audience = config["JwtSettings:Audience"] ?? throw new ArgumentNullException("JwtSettings:Audience");
			
			return new JwtService(key, issuer, audience);
		});

		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
		});

		return services;
	}
}
