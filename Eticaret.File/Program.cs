

using Eticaret.File;
using Eticaret.File.Constants;
using Eticaret.File.Seeders;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FileDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString(ConnectionSettings.DB_CONNECTION), b => b.MigrationsAssembly("Eticaret.File"));
});
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<FileDbContext>();

    var seeder = new FileSeeder();
    await seeder.Seed(context);
}
app.Run();



