using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.File.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController(IFileService fileServices) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImages(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya boş veya mevcut değil.");

            var fileName = await fileServices.UploadFileAsync(file);
            return CreatedAtAction(nameof(DownloadImages), new { fileName }, fileName);
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> DownloadImages(string fileName)
        {
            FileDto? file = await fileServices.DownloadFileAsync(fileName);
            if (file == null)
                return NotFound("Dosya mevcut değil.");

            return File(file.Data, file.ContentType, file.Name);
        }

        [HttpDelete("{fileName}")]
        public async Task<IActionResult> DeleteImages(string fileName)
        {
            bool result = await fileServices.DeleteFileAsync(fileName);
            if (result)
                return Ok("Dosya başarıyla silindi.");
            else
                return StatusCode(500, "Dosya silinirken bir hata oluştu.");
        }
    }
}