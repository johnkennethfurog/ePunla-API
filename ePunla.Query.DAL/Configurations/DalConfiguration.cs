using ePunla.Query.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Query.DAL.Configurations
{
    public static class DalConfiguration
    {
        public static void ConfigureDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFarmerContext, FarmerContext>();
            services.AddTransient<IAuthenticationContext, AuthenticationContext>();
            services.AddTransient<ICropsContext, CropsContext>();
            services.AddTransient<IMasterListContext, MasterListContext>();
            services.AddTransient<IAdminContext, AdminContext>();
        }
    }
}
