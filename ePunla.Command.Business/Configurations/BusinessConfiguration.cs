using ePunla.Command.DAL.Configurations;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Command.Business.Configurations
{
    public static class BusinessConfiguration
    {
        public static void ConfigureBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureDAL(configuration);
            services.AddMediatR(typeof(BusinessConfiguration).Assembly);
        }
    }
}
