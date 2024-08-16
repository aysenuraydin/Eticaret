
using System.Reflection;
using Eticaret.Dto;
using FluentValidation.AspNetCore;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace Eticaret.Web.Mvc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebMvcServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<AdminCategoryCreateDTOValidator>();
            });

            var logFilePathFormat = configuration["Serilog:WriteTo:0:Args:pathFormat"] ?? "";
            var logFilePath = logFilePathFormat.Replace("{Date}", DateTime.Now.ToString("yyyy-MM-dd"));

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: logFilePath,
                    outputTemplate: configuration["Serilog:WriteTo:0:Args:outputTemplate"] ?? "")
                .Enrich.FromLogContext()
                .CreateLogger();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddHttpClient("api", (provider, client) =>
            {
                client.BaseAddress = new Uri("http://localhost:5177/api/");

                IHttpContextAccessor contextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                var context = contextAccessor.HttpContext;
                var token = context?.Items["jwt"]?.ToString();
                if (!string.IsNullOrEmpty(token))
                {
                    client.SetBearerToken(token);
                }
            });

            services.AddHttpClient("fileApi", (provider, client) =>
            {
                client.BaseAddress = new Uri("http://localhost:7044/api/");
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.MapInboundClaims = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = JwtClaimTypes.Name,
                        RoleClaimType = JwtClaimTypes.Role,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        ClockSkew = TimeSpan.Zero,
                        RequireSignedTokens = false,
                        ValidateIssuerSigningKey = false,
                        SignatureValidator = (token, parameters) => new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(token) //!
                    };
                });

            services.AddAuthorization();

            return services;
        }
    }
}
