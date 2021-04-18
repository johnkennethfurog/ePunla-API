using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ePunla.Common.Database.Configurations;

namespace ePunla.Query.DAL.Configurations
{
    public static class DalConfiguration
    {
        public static void ConfigureDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDatabase(configuration);
        }
    }
}
