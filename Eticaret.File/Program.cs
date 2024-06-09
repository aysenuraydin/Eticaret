

using Eticaret.File;
using Eticaret.File.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FileDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnection"), b => b.MigrationsAssembly("Eticaret.File"));
});
builder.Services.AddScoped<IFileServices, FileServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "_myAllowOrigins",
        builder =>
        {
            builder.WithOrigins("http://127.0.0.1:5177")
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles")),
    RequestPath = "/files"
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseRouting();

//app.UseCors("_myAllowOrigins");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

app.UseHttpsRedirection();

