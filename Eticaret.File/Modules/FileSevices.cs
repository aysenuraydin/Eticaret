using System;
using System.IO;
using System.Threading.Tasks;
using Eticaret.File.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Eticaret.File
{
    public class FileServices : IFileServices
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        private readonly FileDbContext _dbContext;

        public FileServices(FileDbContext dbContext, IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
            _dbContext = dbContext;
        }

        public async Task<FileEntity> UploadFileAsync(FileDto file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file), "File is required");
            }

            var localName = $"{Guid.NewGuid().ToString("n")}.{Path.GetExtension(file.Name).TrimStart('.')}";
            var extension = Path.GetExtension(file.Name).TrimStart('.');
            var originalName = Path.GetFileNameWithoutExtension(file.Name);

            var fileSaveLocation = _config["FileSaveLocation"]
                ?? throw new InvalidOperationException("FileSaveLocation is required in the appsettings.json file.");

            fileSaveLocation = Path.Combine(_env.ContentRootPath, fileSaveLocation);

            if (!Directory.Exists(fileSaveLocation))
            {
                Directory.CreateDirectory(fileSaveLocation);
            }

            var filePath = Path.Combine(fileSaveLocation, localName);

            await System.IO.File.WriteAllBytesAsync(filePath, file.Data);

            var fileEntity = new FileEntity
            {
                OriginalName = originalName,
                LocalName = localName,
                ContentType = file.ContentType,
                Extension = extension,
                Size = file.Size,
                FilePath = filePath,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Files.AddAsync(fileEntity);
            int saveResult = await _dbContext.SaveChangesAsync();
            if (saveResult > 0)
                return fileEntity;
            else
                return new();
        }
        public async Task<bool> DeleteFileAsync(string fileName)
        {

            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }
            string directory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", fileName);

            if (System.IO.File.Exists(directory))
            {
                try
                {
                    System.IO.File.Delete(directory);

                    var fileEntity = _dbContext.Files.FirstOrDefault(i => i.LocalName == fileName);

                    if (fileEntity == null) return false;


                    _dbContext.Files.Remove(fileEntity);
                    var IsSuccess = await _dbContext.SaveChangesAsync();

                    if (IsSuccess > 0) return true; //başarı ile silindiyse
                    else return false;

                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
