using Eticaret.File.Constants;
using Eticaret.File.Data;

namespace Eticaret.File
{
    public class FileService : IFileService
    {
        private readonly string _storagePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        private readonly FileDbContext _dbContext;

        public FileService(FileDbContext dbContext, IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
            _dbContext = dbContext;

            if (!Directory.Exists(_storagePath))
                Directory.CreateDirectory(_storagePath);
        }
        public async Task<string> UploadFileAsync(IFormFile file)
        {
            FileEntity fileEntity;
            await using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);

                var localName = $"{Guid.NewGuid().ToString("n")}.{Path.GetExtension(file.FileName).TrimStart('.')}";
                var extension = Path.GetExtension(file.FileName).TrimStart('.');
                var originalName = Path.GetFileNameWithoutExtension(file.FileName);
                var fileSaveLocation = Path.Combine(_env.ContentRootPath, _config[ApplicationSettings.FileSaveLocation]!);
                var filePath = Path.Combine(fileSaveLocation, localName);

                await System.IO.File.WriteAllBytesAsync(filePath, memoryStream.ToArray());

                fileEntity = new()
                {
                    OriginalName = originalName,
                    LocalName = localName,
                    ContentType = file.ContentType,
                    Extension = extension,
                    Size = memoryStream.ToArray().Length,
                    FilePath = filePath,
                    CreatedAt = DateTime.UtcNow
                };
            }

            await _dbContext.Files.AddAsync(fileEntity);
            int saveResult = await _dbContext.SaveChangesAsync();

            if (saveResult > 0)
                return fileEntity.LocalName;
            else throw new Exception("File upload failed");

        }
        public async Task<byte[]> DownloadFileAsync(string fileName)
        {
            var filePath = Path.Combine(_storagePath, fileName);

            if (System.IO.File.Exists(filePath))
            {
                return await System.IO.File.ReadAllBytesAsync(filePath);
            }

            return null;
        }
        public async Task<bool> DeleteFileAsync(string fileName)
        {

            if (string.IsNullOrEmpty(fileName)) return false;

            string directory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", fileName);

            System.IO.File.Delete(directory);

            var fileEntity = _dbContext.Files.FirstOrDefault(i => i.LocalName == fileName);

            if (fileEntity == null) return false;


            _dbContext.Files.Remove(fileEntity);
            var IsSuccess = await _dbContext.SaveChangesAsync();

            if (IsSuccess > 0) return true; //başarı ile silindiyse
            return false;
        }
    }
}

