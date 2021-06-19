using ePunla.Command.DAL.interfaces;
using ePunla.Command.DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Command.DAL.Configurations
{
    public static class DalConfiguration
    {
        public static void ConfigureDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IFarmerContext, FarmerContext>();
            services.AddScoped<IAdminContext, AdminContext>();
        }
    }
}
