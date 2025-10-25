using ServiceLayer.Interfaces;
using ServiceLayer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ServiceLayer
{
	public static class ServiceLayerConfig
	{
		public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IHomeService, HomeService>();

			return services;
		}
	}
}
