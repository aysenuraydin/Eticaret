using Eticaret.Persistence.Ef;
using Eticaret.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Eticaret.Web.Mvc;
using Microsoft.Extensions.FileProviders;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options =>
{
    options.Cookie.Name = "MyCookie";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.LoginPath = "/Auth/Login";
    options.LogoutPath = "/Home/Index";
});
builder.Services.AddAuthorization();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "/Users/aysenuraydin/Documents/GitHub/Eticaret/Eticaret.File/UploadedFiles");
var fileProvider = new PhysicalFileProvider(rootPath);
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = "/UploadedFiles"
});

app.UseRouting();

app.UseMiddleware<CustomMiddleware>();

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
