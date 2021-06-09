using ePunla.Command.Business.Services;
using ePunla.Command.Business.Services.Interfaces;
using ePunla.Command.Business.Utilities;
using ePunla.Command.DAL.Configurations;
using ePunla.Common.Utilitites.Configurations;
using ePunla.Common.Utilitites.Interfaces;
using ePunla.Common.Utilitites.Services;
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
            services.AddTransient<IPhotoService, PhotoService>();
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
