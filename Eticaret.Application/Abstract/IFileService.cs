using Microsoft.AspNetCore.Http;

namespace Eticaret.Application.Abstract
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<byte[]> DownloadFileAsync(string fileName);
        Task<bool> DeleteFileAsync(string fileName);
    }
}
