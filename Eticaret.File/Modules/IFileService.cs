using Eticaret.Dto;

namespace Eticaret.File
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<FileDto?> DownloadFileAsync(string fileName);
        Task<bool> DeleteFileAsync(string fileName);
    }
}
