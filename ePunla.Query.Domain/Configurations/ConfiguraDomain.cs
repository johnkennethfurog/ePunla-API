using ePunla.Common.Utilitites.DbConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ePunla.Query.Domain.Configurations
{
    public static class DomainConfiguration
    {
        public static void ConfigureDomain(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDatabaseConnection>(e => new DatabaseConnection(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
