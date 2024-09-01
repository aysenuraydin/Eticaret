using Eticaret.File.Data;
using Microsoft.EntityFrameworkCore;

public class FileDbContext : DbContext
{
    public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
    {
    }

    public DbSet<FileEntity> Files { get; set; }
}