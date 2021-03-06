using System;
using ePunla.Common.Utilitites.DbConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Command.Domain.Configurations
{
    public static class DomainConfiguration
    {
        public static void ConfigureDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDatabaseConnection>(e => new DatabaseConnection(Environment.GetEnvironmentVariable("CONNECTION_STRING")));
        }
    }
}
  