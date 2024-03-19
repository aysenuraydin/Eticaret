using Eticaret.Persistence.Ef;
using Eticaret.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // admin login i�in ekliyoruz.
app.UseAuthorization(); // kullan�c� yetkilendirme

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}"
    );

// using var scope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();
// using var context = scope.ServiceProvider.GetService<EticaretDbContext>()!;
// context.Database.EnsureDeleted();
// context.Database.EnsureCreated();

app.Run();