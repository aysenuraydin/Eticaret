using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;

namespace Eticaret.Web.Mvc.Services
{
    public class ApiFileService(IHttpClientFactory httpFactory) : IFileService
    {//!!!!
        private HttpClient Client => httpFactory.CreateClient(ApplicationSettings.FILE_API_CLIENT);
        public async Task<bool> DeleteFileAsync(string fileName)
        {
            var response = await Client.DeleteAsync($"api/file/{fileName}");
            return response.IsSuccessStatusCode;
        }

        public async Task<FileDto?> DownloadFileAsync(string fileName)
        {
            var response = await Client.GetAsync($"api/file/{fileName}");
            if (!response.IsSuccessStatusCode)
                return null;

            ArgumentException.ThrowIfNullOrWhiteSpace(response.Content?.Headers.ContentType?.MediaType);

            return new FileDto
            {
                Data = await response.Content.ReadAsByteArrayAsync(),
                ContentType = response.Content?.Headers.ContentType.MediaType,
                Name = fileName
            };
        }

        public async Task<string?> UploadFileAsync(IFormFile file)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var multiPartFormDataContent = new MultipartFormDataContent
            {
                { new ByteArrayContent(ms.ToArray()), "file", file.FileName }
            };

            var response = await Client.PostAsync("api/file", multiPartFormDataContent);
            if (!response.IsSuccessStatusCode)
                return null;

            return $"{Client.BaseAddress}{response.Headers.Location?.ToString()}";
        }

        Task<byte[]> IFileService.DownloadFileAsync(string fileName) //!!
        {
            throw new NotImplementedException();
        }
    }
}
