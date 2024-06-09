

using System.Text;
using Eticaret.Application;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

var secret = builder.Configuration.GetSection("AppSettings:Secret").Value;

// secret değişkeninin null olmadığından emin olun
if (string.IsNullOrEmpty(secret))
{
    throw new InvalidOperationException("Secret key cannot be null or empty.");
}
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.MaxDepth = 64;
    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = "yourdomain.com", // Token'ın üretildiği yer
        //ValidAudience = "yourdomain.com", // Token'ın kullanılacağı yer
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)) // Güvenlik anahtarı
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.Request.Cookies["token"];
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<EticaretDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
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

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("_myAllowOrigins",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5177")
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<UnauthorizedMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

// app.Use(async (context, next) =>
// {
//     var token = context.Request.Cookies["AuthToken"];
//     if (!string.IsNullOrEmpty(token))
//     {
//         if (context.Request.Headers.ContainsKey("Authorization"))
//         {
//             context.Request.Headers.Remove("Authorization");
//         }
//         context.Request.Headers.Append("Authorization", "Bearer " + token);
//     }
//     await next();
// });

app.UseCors("_myAllowOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
