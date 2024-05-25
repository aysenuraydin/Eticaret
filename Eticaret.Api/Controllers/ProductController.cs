using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productService;

        public ProductController(IProductRepository productService)
        {
            _productService = productService;
        }
        [HttpGet]

        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetIdAllIncludeFilterAsync(
                                        p => p.IsConfirmed && p.Enabled && p.StockAmount > 0,
                                        p => p.ProductImages
                                       );

            var prd = products
                         .OrderByDescending(p => p.CreatedAt)
                         .Select(p => ProductListToDTO(p));

            return Ok(prd);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetIdAllIncludeFilterAsync(
                          p => p.Id == id,
                          p => p.CategoryFk!,
                          p => p.SellerFk!,
                          p => p.ProductComments,
                          p => p.ProductImages
                         );


            if (product == null) return NotFound();

            var prd = product.Select(p => ProductDetailToDTO(p))
                             .FirstOrDefault();

            return Ok(prd);
        }
        private static ProductListDTO ProductListToDTO(Product p)
        {
            ProductListDTO entity = new();
            if (p != null)
            {
                entity.Id = p.Id;
                entity.Name = p.Name;
                entity.Price = p.Price;
                entity.ImageUrl = p.ProductImages.FirstOrDefault()?.Url!;
            }
            return entity;
        }
        private static ProductDetailDTO ProductDetailToDTO(Product p)
        {

            return new ProductDetailDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Details = p.Details,
                StockAmount = p.StockAmount,
                CategoryName = p.CategoryFk?.Name ?? string.Empty,
                SellerName = $"{p.SellerFk?.FirstName ?? string.Empty} {p.SellerFk?.LastName ?? string.Empty}".Trim(),
                ProductImagesUrl = p.ProductImages.Select(p =>
                new Images
                {
                    Id = p.Id,
                    Url = p.Url,
                })
                .ToList(),

                ProductComments = p.ProductComments.Select(p =>
                new Comment
                {
                    Id = p.Id,
                    Text = p.Text,
                    StarCount = p.StarCount,
                    IsConfirmed = p.IsConfirmed,
                    CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy"),
                    UserName = p.UserFk?.Email ?? ""
                })
                .ToList()

            };
        }
    }
}

