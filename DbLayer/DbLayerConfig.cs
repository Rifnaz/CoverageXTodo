using DbLayer.Data;
using DbLayer.Interfaces;
using DbLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbLayer
{
	public static class DbLayerConfig
	{
		public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
		{
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<AppDbContext>(option =>{option.UseSqlServer(connectionString);}, ServiceLifetime.Scoped);
			services.AddTransient<IHomeRepository, HomeRepository>();

			return services;
		}
	}
}
