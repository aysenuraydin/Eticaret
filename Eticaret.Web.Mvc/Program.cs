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
    pattern: "{controller=Template}/{action=Index}/{id?}"
    );

app.Run();