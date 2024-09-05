using Eticaret.File.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Eticaret.File.Seeders
{
    public class FileSeeder : ISeeder
    {
        public async Task Seed(FileDbContext context)
        {
            if (context.Files.Any()) return;

            // Test verilerini oluştur
            var testFiles = new[] { "yelek", "triko", "sweatshirt", "sort", "kazak", "elbise", "ceket", "pantolon", "etek", "bluz" };

            foreach (var item in testFiles)
            {
                for (int i = 1; i <= 5; i++)
                {
                    FileEntity entity = new()
                    {
                        OriginalName = $"{item}-0{i}.jpg",
                        LocalName = $"{item}-0{i}.jpg",
                        ContentType = "application/octet-stream"
                    };
                    await context.Files.AddAsync(entity);
                }
            };
            await context.SaveChangesAsync();
        }
    }
}
