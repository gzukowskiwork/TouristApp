using Microsoft.Extensions.Configuration;

namespace TouristAppBackend.Application.Common.Configuration
{
    public abstract class BaseConfiguration
    {
        protected IConfiguration Configuration { get; }

        protected BaseConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}
