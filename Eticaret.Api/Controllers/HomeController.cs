using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public HomeController(IProductRepository productRepo)
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
            var productList = (await _productRepo.GetIdAllIncludeFilterAsync(
                                       p => p.IsConfirmed && p.Enabled && p.StockAmount > 0 && p.CategoryId == id,
                                       p => p.ProductImages
                                      ))
                                      .OrderByDescending(p => p.CreatedAt)
                                      .Select(p => ProductListToDTO(p))
                                      .ToList();

            return Ok(productList);

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
    }
}
