using ePunla.Common.Utilitites.Helpers;
using Microsoft.AspNetCore.Builder;

namespace ePunla.Common.Utilitites.Configurations
{
    public static class AppBuilder
    {
        public static IApplicationBuilder UseCommonUtilities(this IApplicationBuilder builder)
        {
            return builder
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(CorsHelper.CORS_POLICY)
                .UseAuthentication()
                .UseAuthorization()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dot Net Masters API");
                });
        }
    }
}
