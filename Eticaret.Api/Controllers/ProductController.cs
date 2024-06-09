using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("~/api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }
        [HttpGet]

        public async Task<IActionResult> GetProducts()
        {
            var products = (await _productRepo.GetIdAllIncludeFilterAsync(
                         p => p.IsConfirmed && p.Enabled && p.StockAmount > 0,
                         p => p.ProductImages
                        ))
                         .OrderByDescending(p => p.CreatedAt)
                         .Select(p => ProductListToDTO(p))
                         .ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = (await _productRepo.GetIdAllIncludeFilterAsync(
                          p => p.Id == id,
                          p => p.CategoryFk!,
                          p => p.UserFk!,
                          p => p.ProductComments,
                          p => p.ProductImages
                         )).FirstOrDefault();


            if (product == null) return NotFound();
            return Ok(ProductDetailToDTO(product));
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
                SellerName = $"{p.UserFk?.FirstName ?? string.Empty} {p.UserFk?.LastName ?? string.Empty}".Trim(),
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

