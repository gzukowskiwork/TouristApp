using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Application.Common.Interfaces.ExternalApi;
using TouristAppBackend.Application.Common.Interfaces.Validators;
using TouristAppBackend.Infrastructure.ExternalApi;
using TouristAppBackend.Infrastructure.FileStore;
using TouristAppBackend.Infrastructure.Services;

namespace TouristAppBackend.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IFileStore, FileStore.FileStore>();
            services.AddTransient<IFileWrapper, FileWrapper>();
            services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
            services.AddTransient<IImageFileValidator, ImageFileValidator>();
            services.AddTransient<IGpxFileValidator, GpxFileValidator>();
            services.AddTransient<IGpxProcessor, GpxProcessor>();
            services.AddTransient<IAvarageRank, AvarageRankService>();
            services.AddTransient<IOpenTripMap, OpenTripMap>();

            return services;
        }
    }
}
