

using Eticaret.File.Data;

namespace Eticaret.File
{
    public interface IFileServices
    {

        Task<FileEntity> UploadFileAsync(FileDto file);

        Task<bool> DeleteFileAsync(string fileName);


    }
}
