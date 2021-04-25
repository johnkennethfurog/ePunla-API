using System.Collections.Generic;
using System.Reflection;
using ePunla.Common.Utilitites.PipelinesBehavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ePunla.Common.Utilitites.Configurations
{
    public static class AppConfiguration
    {
        public static void ConfigureAppApi(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "E-Punla", Version = "v1", });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter into field the word 'Bearer' following by space and JWT",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new List<string>()
                    }
                });

            });
        }

        public static void ConfigureAppBusiness(this IServiceCollection services, Assembly businessAssembly)
        {
            services.AddMediatR(businessAssembly);
            services.AddAutoMapper(businessAssembly);

            // For all the validators, register them with dependency injection as scoped
            AssemblyScanner.FindValidatorsInAssembly(businessAssembly)
              .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            // Add the custome pipeline validation to DI
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

    }
}
