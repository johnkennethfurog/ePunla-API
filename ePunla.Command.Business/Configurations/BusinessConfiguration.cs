using ePunla.Command.DAL.Configurations;
using ePunla.Common.Utilitites.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Command.Business.Configurations
{
    public static class BusinessConfiguration
    {
        public static void ConfigureBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDAL(configuration);
            services.ConfigureAppBusiness(typeof(BusinessConfiguration).Assembly);
        }
    }
}
