using ePunla.Query.Business.Configurations;
using ePunla.Query.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Query.API.Configurations
{
    public static class ApiConfiguration
    {
        public static void ConfigureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureBusiness(configuration);
            services.ConfigureDomain(configuration);
        }
    }
}
