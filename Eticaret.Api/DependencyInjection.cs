using Eticaret.Domain;
using Eticaret.Persistence.Ef;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;

namespace Eticaret.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            var logFilePathFormat = configuration["Serilog:WriteTo:0:Args:pathFormat"] ?? "";
            var logFilePath = logFilePathFormat.Replace("{Date}", DateTime.Now.ToString("yyyy-MM-dd"));

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    path: logFilePath,
                    outputTemplate: configuration["Serilog:WriteTo:0:Args:outputTemplate"] ?? "")
                .Enrich.FromLogContext()
                .CreateLogger();

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
                options.SaveToken = true;//? //!
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    NameClaimType = JwtClaimTypes.Name,//!
                    RoleClaimType = JwtClaimTypes.Role//!
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


            // services.AddFluentValidation(fv =>
            // {
            //     fv.RegisterValidatorsFromAssemblyContaining<AdminCategoryCreateDTOValidator>();
            // });

            // services.Configure<ApiBehaviorOptions>(options =>
            // {
            //     options.SuppressModelStateInvalidFilter = true;
            // });
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
                        builder//.WithOrigins("http://127.0.0.1:5177") //!yanlış //mvc adresi olmalıydı
                            .AllowAnyOrigin()//ya yukarıdaki ya da bu satır.
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                        // .AllowCredentials();
                    });
            });

            return services;
        }
    }
}
