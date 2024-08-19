using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Eticaret.File.Data;

namespace Eticaret.File
{
    public class FileServices : IFileService
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

        public async Task<string?> UploadFileAsync(IFormFile file)
        {
            var fileDto = new FileDto();
            await using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileDto.Data = memoryStream.ToArray();
                fileDto.ContentType = file.ContentType;
                fileDto.Name = file.FileName;
            }

            ArgumentNullException.ThrowIfNull(file);

            var localName = $"{Guid.NewGuid().ToString("n")}.{Path.GetExtension(fileDto.Name).TrimStart('.')}";
            var extension = Path.GetExtension(fileDto.Name).TrimStart('.');
            var originalName = Path.GetFileNameWithoutExtension(fileDto.Name);

            var fileSaveLocation = _config["FileSaveLocation"]
                ?? throw new InvalidOperationException("FileSaveLocation is required in the appsettings.json file.");

            fileSaveLocation = Path.Combine(_env.ContentRootPath, fileSaveLocation);

            if (!Directory.Exists(fileSaveLocation))
            {
                Directory.CreateDirectory(fileSaveLocation);
            }

            var filePath = Path.Combine(fileSaveLocation, localName);

            await System.IO.File.WriteAllBytesAsync(filePath, fileDto.Data);

            var fileEntity = new FileEntity
            {
                OriginalName = originalName,
                LocalName = localName,
                ContentType = fileDto.ContentType,
                Extension = extension,
                Size = fileDto.Data.Length,
                FilePath = filePath,
                CreatedAt = DateTime.UtcNow
            };

            await _dbContext.Files.AddAsync(fileEntity);
            int saveResult = await _dbContext.SaveChangesAsync();

            return saveResult > 0 ? localName : null;
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

        public async Task<FileDto?> DownloadFileAsync(string fileName)
        {
            var fileSaveLocation = _config["FileSaveLocation"]
                ?? throw new InvalidOperationException("FileSaveLocation is required in the appsettings.json file.");

            fileSaveLocation = Path.Combine(_env.ContentRootPath, fileSaveLocation);
            var filePath = Path.Combine(fileSaveLocation, fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return null;
            }

            var fileEntity = _dbContext.Files.FirstOrDefault(i => i.LocalName == fileName);
            if (fileEntity is null) return null;

            ArgumentNullException.ThrowIfNull(fileEntity.ContentType);

            return new FileDto
            {
                Data = await System.IO.File.ReadAllBytesAsync(filePath),
                ContentType = fileEntity.ContentType,
                Name = fileEntity.OriginalName
            };
        }
    }
}
