using ePunla.Common.Utilitites.Configurations;
using ePunla.Common.Utilitites.Interfaces;
using ePunla.Common.Utilitites.Services;
using ePunla.Query.DAL.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Query.Business.Configurations
{
    public static class BusinessConfiguration
    {
        public static void ConfigureBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDAL(configuration);
            services.ConfigureAppBusiness(typeof(BusinessConfiguration).Assembly);

            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
