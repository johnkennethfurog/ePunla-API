using System;
using ePunla.Command.Business.Configurations;
using ePunla.Command.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Command.API.Configurations
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
