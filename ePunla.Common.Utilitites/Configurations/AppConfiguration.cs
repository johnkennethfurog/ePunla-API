using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ePunla.Common.Utilitites.Helpers;
using ePunla.Common.Utilitites.PipelinesBehavior;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace ePunla.Common.Utilitites.Configurations
{
    public static class AppConfiguration
    {
        public static void ConfigureAppApi(this IServiceCollection services, IConfiguration configuration)
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

            services.AddCors(options => {
                options.AddPolicy(CorsHelper.CORS_POLICY,
                    policyBuilder =>
                        policyBuilder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
                        
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
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
