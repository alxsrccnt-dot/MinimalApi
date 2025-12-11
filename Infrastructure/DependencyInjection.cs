using Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration config)
	{
		services.AddDatabaseContext(config);
		
		return services;
	}

	private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
	{
		services.AddDbContext<ApplicationDbContext>((so, options) =>
		{
			string? connectionString = config 
		});


		return services;
	}
}
