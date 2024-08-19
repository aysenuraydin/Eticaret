using Eticaret.Dto;
using Microsoft.AspNetCore.Http;

namespace Eticaret.Application.Abstract
{
    public interface IFileService
    {
        Task<string?> UploadFileAsync(IFormFile file);

        Task<FileDto?> DownloadFileAsync(string fileName);

        Task<bool> DeleteFileAsync(string fileName);
    }
}
