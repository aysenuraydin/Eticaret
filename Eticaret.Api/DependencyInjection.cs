using System.Text;
using Eticaret.Api.Constants;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;
using Eticaret.WebApi.Models.ConfigModels;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

namespace Eticaret.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<SerilogConfigModel>()
            .Bind(configuration.GetSection(SerilogSettings.SERİLOG))
            .ValidateDataAnnotations();

            var serilogConfig = configuration.GetSection(SerilogSettings.SERİLOG).Get<SerilogConfigModel>();

            if (serilogConfig == null) throw new Exception("Serilog yapılandırması bulunamadı!");

            var logFilePathFormat = serilogConfig.WriteTo[0].Args.PathFormat;
            var logFilePath = logFilePathFormat.Replace("{Date}", DateTime.Now.ToString("yyyy-MM-dd"));
            var OutputTemplate = serilogConfig.WriteTo[0].Args.OutputTemplate;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(
                    path: logFilePath,
                    outputTemplate: OutputTemplate)
                .Enrich.FromLogContext()
                .CreateLogger();

            //!
            var key = Encoding.ASCII.GetBytes(configuration[ApplicationSettings.CONFIG_SECRET_KEY]!);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.MapInboundClaims = false;
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    NameClaimType = JwtClaimTypes.Name,
                    RoleClaimType = JwtClaimTypes.Role
                };
                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = async (context) =>
                    {
                        var token = context.Token;
                        await Task.CompletedTask;
                    },
                    OnChallenge = async (context) =>
                    {
                        await Task.CompletedTask;
                    },
                    OnAuthenticationFailed = async (context) =>
                    {
                        await Task.CompletedTask;
                    }
                };
            });

            services.AddAuthorization();

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<EticaretDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            });

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{}
            }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(ApplicationSettings.CORS_KEY,
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            return services;
        }
    }
}
