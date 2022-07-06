using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TouristAppBackend.Infrastructure.Security.Interfaces;
using TouristAppBackend.Infrastructure.Security.Services;

namespace TouristAppBackend.Infrastructure.Security
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddInfrastructureSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IIdentityService, IdetityService>();

            return services;
        }
    }
}
