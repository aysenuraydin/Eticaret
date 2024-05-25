using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageService;
        public ProductImageController(
            IProductImageRepository productImageService
            )
        {
            _productImageService = productImageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImages(int? id)
        {
            if (id == null) return NotFound();

            var images = await _productImageService.GetIdAllIncludeFilterAsync(
                          p => p.ProductId == id,
                          p => p.SellerFk!
                         );

            if (images == null) return NotFound();

            var img = images
                        .OrderByDescending(p => p.CreatedAt)
                        .Select(p => ProductImageListToDTO(p))
                        .ToList();
            return Ok(img);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductImageCreateDTO image)
        {
            try
            {
                var img = ProductImageCreateToDTO(image);
                await _productImageService.AddAsync(img);
                return CreatedAtAction(nameof(GetImages), new { id = img.ProductId }, img);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImages(int? id)
        {
            if (id == null) return NotFound();

            var prd = await _productImageService.GetAllAsync(i => i.ProductId == id);

            if (prd == null) return NotFound();

            try
            {
                var deleteTasks = prd.Select(i => _productImageService.DeleteAsync(i));
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
                Url = p.Url,
                CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy"),
                ProductId = p.ProductId,
                SellerId = p.SellerId
            };
        }
        private static ProductImage ProductImageCreateToDTO(ProductImageCreateDTO p)
        {
            return new ProductImage
            {
                Url = p.Url ?? Guid.NewGuid().ToString(),
                ProductId = p.ProductId,
                SellerId = p.SellerId
            };
        }
    }
}

