using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("~/api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepo;
        public ProductImageController(IProductImageRepository productImageRepo)
        {
            _productImageRepo = productImageRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            var images = (await _productImageRepo.GetAllIncludeAsync(
                          p => p.UserFk
                         ))
                         .OrderByDescending(p => p.CreatedAt)
                         .Select(p => ProductImageListToDTO(p))
                         .ToList();

            if (images == null) return NotFound();

            return Ok(images);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetImages(int? id)
        {
            if (id == null) return NotFound();

            var images = (await _productImageRepo.GetIdAllIncludeFilterAsync(
                          p => p.ProductId == id,
                          p => p.UserFk
                         ))
                         .OrderByDescending(p => p.CreatedAt)
                         .Select(p => ProductImageListToDTO(p))
                         .ToList();

            if (images == null) return NotFound();

            return Ok(images);
        }

        [HttpPost]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> CreateProduct(ProductImageCreateDTO image)
        {
            if (image == null) return NotFound();

            try
            {
                var img = ProductImageCreateToDTO(image);
                await _productImageRepo.AddAsync(img);

                return CreatedAtAction(nameof(GetImages), new { id = img.ProductId }, img);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "seller")]
        public async Task<IActionResult> DeleteImages(int? id)
        {
            if (id == null) return NotFound();

            var prd = await _productImageRepo.GetAllAsync(i => i.ProductId == id);

            if (prd == null || !prd.Any()) return NotFound();

            try
            {
                var deleteTasks = prd
                                .Where(i => i != null)
                                .Select(i => _productImageRepo.DeleteAsync(i!));
                await Task.WhenAll(deleteTasks);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static ProductImageListDTO ProductImageListToDTO(ProductImage p)
        {
            return new ProductImageListDTO
            {
                Id = p.Id,
                Url = p.Url,
                CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy"),
                ProductId = p.ProductId,
                SellerId = p.UserId
            };
        }

        private static ProductImage ProductImageCreateToDTO(ProductImageCreateDTO p)
        {
            return new ProductImage
            {
                Url = p.Url ?? Guid.NewGuid().ToString(),
                ProductId = p.ProductId,
                UserId = p.SellerId
            };
        }
    }
}

