using System;
using System.Text;
using Infrastructure.Utility;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Host
{
    public static class Extensions
    {
        public static IServiceCollection RegisterModule(this IServiceCollection services, IModuleDescriptor moduleDescriptor)
        {
            moduleDescriptor.GetDescriptions().ForEach(description => services.Add(description));

            return services;
        }

        public static IServiceCollection AddBasicJwtAuthentication(this IServiceCollection services, Model.JwtAuthenticationContext context)
        {
            bool envIsDevelopment = context.Environment != Environment.Development;

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = envIsDevelopment;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = envIsDevelopment,
                        ValidateIssuer = envIsDevelopment,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = context.Issuer,
                        ValidAudience = context.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(context.SecurityKey)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        public static string GetAspNetCoreEnvironmentName(this IConfiguration configuration)
            => configuration["ASPNETCORE_ENVIRONMENT"];

        public static Environment GetAspNetCoreEnvironment(this IConfiguration configuration)
        {
            Environment environment = Environment.Development;

            switch (configuration["ASPNETCORE_ENVIRONMENT"])
            {
                case "Staging":
                    environment = Environment.Staging;
                    break;
                case "Production":
                    environment = Environment.Production;
                    break;
                default:
                    environment = Environment.Development;
                    break;
            }

            return environment;
        }
    }
}