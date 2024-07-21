
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Eticaret.Web.Mvc;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
using System.Net.Http.Headers;
using IdentityModel.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

builder.Services.AddHttpClient("api", (provider, client) => //!
{
    // client.BaseAddress = new Uri("https://localhost:7083/api");
    client.BaseAddress = new Uri("http://localhost:5177/api/");
    // client.DefaultRequestHeaders.Clear();

    // client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    IHttpContextAccessor contextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
    var context = contextAccessor.HttpContext;
    var token = context?.Items["jwt"]?.ToString();
    if (!string.IsNullOrEmpty(token))
    {
        client.SetBearerToken(token);
    }
});

builder.Services.AddHttpClient("fileApi", (provider, client) =>
{
    client.BaseAddress = new Uri("http://localhost:7044/api/");
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseMiddleware<CustomMiddleware>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "/Users/aysenuraydin/Documents/GitHub/Eticaret/Eticaret.File/UploadedFiles");//!dinamik hale getir
var fileProvider = new PhysicalFileProvider(rootPath);

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = "/UploadedFiles"
});

app.UseRouting();

app.UseAuthentication(); // login için 

app.UseAuthorization(); //  yetkilendirme için

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
app.Run();

// using var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();
// using var context = scope.ServiceProvider.GetService<EticaretDbContext>()!;
// context.Database.EnsureDeleted();
// context.Database.EnsureCreated();
