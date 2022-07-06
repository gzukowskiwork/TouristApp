using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TouristAppBackend.Application.Common.Interfaces;

namespace TouristAppBackend.Persistance
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TouristAppContext>(options => options.UseSqlServer(configuration.GetConnectionString("TouristAppDbConnectionString")));

            services.AddScoped<ITouristAppContext, TouristAppContext>();

            services.AddDbContext<UserContext>(options => options.UseSqlServer(configuration.GetConnectionString("UsersConnectionString")));

            services.AddScoped<IUserContext, UserContext>();

            return services;
        }

    }
}
