using Microsoft.AspNetCore.Mvc;

namespace Eticaret.File.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }
        [HttpGet("{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            var fileData = await _fileService.DownloadFileAsync(fileName);
            if (fileData == null)
                return NotFound("File not found.");

            return File(fileData, "application/octet-stream", fileName);
        }
        [HttpPost]
        public async Task<IActionResult> UploadImages(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file.");

            var fileName = await _fileService.UploadFileAsync(file);
            return Ok(fileName);
        }

        [HttpDelete("{fileName}")]
        public async Task<IActionResult> DeleteImages(string fileName)
        {
            bool result = await _fileService.DeleteFileAsync(fileName);
            if (result)
                return Ok("Dosya başarıyla silindi.");

            return StatusCode(500, "Dosya silinirken bir hata oluştu.");
        }
    }
}