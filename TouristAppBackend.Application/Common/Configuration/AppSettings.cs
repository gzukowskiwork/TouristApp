using Microsoft.Extensions.Configuration;
using TouristAppBackend.Application.Common.Interfaces.Configuration;

namespace TouristAppBackend.Application.Common.Configuration
{
    public class AppSettings : BaseConfiguration, IAppSettings
    {
        public long AcceptedFileSize =>long.Parse(Configuration["FileSize:FileSize"]);

        public string OpenWeatherMapApiKey => Configuration["ApiKeys:openWeatherMap"];

        public string OpenTripMapApiKey => Configuration["ApiKeys:openTripMap"];

        public string BaseAddress => Configuration["OpenTripMapConfig:baseAddress"];

        public string Language => Configuration["OpenTripMapConfig:language"];

        public AppSettings(IConfiguration configuration) : base(configuration)
        {
        }

    }
}
