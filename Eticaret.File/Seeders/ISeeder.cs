namespace Eticaret.File.Seeders
{
    public interface ISeeder
    {
        Task Seed(FileDbContext context);
    }
}