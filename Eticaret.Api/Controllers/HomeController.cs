using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _productService;

        public HomeController(IProductRepository productService)
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
            var productList = await _productService.GetIdAllIncludeFilterAsync(
                                       p => p.IsConfirmed && p.Enabled && p.StockAmount > 0,
                                       p => p.ProductImages
                                      );

            if (id != null) productList = productList
                                            .Where(c => c.CategoryId == id)
                                            .ToList();

            var prd = productList
                          .OrderByDescending(p => p.CreatedAt)
                          .Select(p => ProductListToDTO(p));

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
    }
}
