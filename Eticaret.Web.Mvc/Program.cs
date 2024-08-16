
using Microsoft.Extensions.FileProviders;
using Eticaret.Web.Mvc;
using Eticaret.Application;
using Eticaret.Persistence.Ef;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddWebMvcServices(builder.Configuration);

var app = builder.Build();

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

app.UseMiddleware<CustomMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

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
