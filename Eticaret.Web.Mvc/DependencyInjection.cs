
using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Eticaret.Web.Mvc.Models.ConfigModels;
using Eticaret.Web.Mvc.Services;
using FluentValidation.AspNetCore;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllersWithViews();

            services.AddHttpContextAccessor();

            services.AddOptions<FileDownloadConfigModels>()
                    .Bind(configuration.GetSection(ApplicationSettings.FILE_DOWNLOAD_CONFİG))
                    .ValidateDataAnnotations();

            services.AddOptions<DataApiAccessConfigModel>()
                    .Bind(configuration.GetSection(ApplicationSettings.DATA_API_CONFİG))
                    .ValidateDataAnnotations();

            services.AddOptions<FileApiAccessConfigModel>()
                    .Bind(configuration.GetSection(ApplicationSettings.FILE_API_CONFİG))
                    .ValidateDataAnnotations();

            services.AddHttpClient(ApplicationSettings.DATA_API_CLIENT, (provider, client) =>
            {
                var dataApiConfig = provider.GetRequiredService<IOptions<DataApiAccessConfigModel>>().Value;
                ArgumentNullException.ThrowIfNull(dataApiConfig);

                client.BaseAddress = new Uri(dataApiConfig.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(dataApiConfig.TimeoutSeconds);

                if (dataApiConfig.UseJwt)
                {
                    var contextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                    var context = contextAccessor.HttpContext;
                    var token = context?.Items[JWTSettings.JWT]?.ToString();
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.SetBearerToken(token);
                    }
                }
            });

            services.AddHttpClient(ApplicationSettings.FILE_API_CLIENT, (provider, client) =>
            {
                var fileApiConfig = provider.GetRequiredService<IOptions<FileApiAccessConfigModel>>().Value;
                ArgumentNullException.ThrowIfNull(fileApiConfig);

                client.BaseAddress = new Uri(fileApiConfig.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(fileApiConfig.TimeoutSeconds);

                if (fileApiConfig.UseJwt)
                {
                    var contextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
                    var context = contextAccessor.HttpContext;
                    var token = context?.Items[JWTSettings.JWT]?.ToString();
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.SetBearerToken(token);
                    }
                }
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
                        SignatureValidator = (token, parameters) => new Microsoft.IdentityModel.JsonWebTokens.JsonWebToken(token)
                    };
                });

            services.AddAuthorization();
            services.AddScoped<ApiFileService, ApiFileService>();
            return services;
        }
    }
}
