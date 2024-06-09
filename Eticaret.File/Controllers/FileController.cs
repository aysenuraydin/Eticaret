
using Eticaret.File.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.File.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileServices _fileServices;

        public FileController(IFileServices fileServices)
        {
            _fileServices = fileServices;
        }
        [HttpPost]
        public async Task<IActionResult> UploadImages(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya boş veya mevcut değil.");

            var fileDto = new FileDto();
            await using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileDto.Data = memoryStream.ToArray();
                fileDto.ContentType = file.ContentType;
                fileDto.Name = file.FileName;
            }

            FileEntity fileName = await _fileServices.UploadFileAsync(fileDto);
            return Ok(fileName);
        }

        [HttpDelete("{fileName}")]
        public async Task<IActionResult> DeleteImages(string fileName)
        {
            bool result = await _fileServices.DeleteFileAsync(fileName);
            if (result)
                return Ok("Dosya başarıyla silindi.");
            else
                return StatusCode(500, "Dosya silinirken bir hata oluştu.");
        }
    }
}