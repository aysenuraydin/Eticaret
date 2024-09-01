namespace Eticaret.File
{
    public interface IFileService
    {

        Task<string> UploadFileAsync(IFormFile file);
        Task<byte[]> DownloadFileAsync(string fileName);
        Task<bool> DeleteFileAsync(string fileName);
    }
}
