using System.Drawing;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerProductController : ControllerBase
    {
        private readonly IProductRepository _productService;
        public SellerProductController(IProductRepository productService)
        {
            _productService = productService;
        }
        [HttpGet("All/{id}")]
        public async Task<IActionResult> GetProducts(int? id)
        {
            var products = await _productService.GetIdAllIncludeFilterAsync(
                                        p => p.SellerId == id,
                                        p => p.ProductImages,
                                        p => p.ProductComments,
                                        p => p.SellerFk!,
                                        p => p.CategoryFk!,
                                        p => p.OrderItems,
                                        p => p.CartItems
                                       );

            var prd = products
                     .OrderByDescending(p => p.CreatedAt)
                     .Select(p => ProductListToDTO(p))
                     .ToList();

            return Ok(prd);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productService.GetIdAllIncludeFilterAsync(
                          p => p.Id == id,
                          p => p.ProductImages,
                          p => p.ProductComments,
                          p => p.SellerFk!,
                          p => p.CategoryFk!,
                          p => p.OrderItems,
                          p => p.CartItems
                         );

            if (product == null) return NotFound();

            var prd = product.Select(p => ProductDetailToDTO(p))
                        .FirstOrDefault();
            return Ok(prd);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(SellerProductCreateDTO entity)
        {
            try
            {
                var p = ProductCreateToDTO(entity);
                await _productService.AddAsync(p);
                return CreatedAtAction(nameof(GetProduct), new { id = p.Id }, p);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(SellerProductUpdateDTO p)
        {
            var prd = await _productService.GetAsync(i => i.Id == p.Id);

            if (prd == null) return NotFound();

            try
            {
                await _productService.UpdateAsync(ProductUpdateToDTO(p, prd));
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(prd);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null) return NotFound();

            var prd = await _productService.GetAsync(i => i.Id == id);

            if (prd == null) return NotFound();

            try
            {
                await _productService.DeleteAsync(prd);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        private static SellerProductListDTO ProductListToDTO(Product p)
        {
            return new SellerProductListDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrlList = p.ProductImages.Select(i => i.Url ?? "").Where(url => url != "").ToList()!,
                Details = p.Details,
                StockAmount = p.StockAmount,
                Enabled = p.Enabled,
                IsConfirmed = p.IsConfirmed,
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryFk!.Name ?? "",
                CategoryColor = p.CategoryFk!.Color ?? "",
                SellerName = $"{p.SellerFk!.FirstName} {p.SellerFk.LastName}",
                CommentCount = p.ProductComments.Count,
                OrderCount = p.OrderItems.Count,
                CartCount = p.CartItems.Count,
                CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy"),
            };
        }

        private static Product ProductUpdateToDTO(SellerProductUpdateDTO p, Product prd)
        {
            prd.Id = p.Id;
            prd.Name = p.Name;
            prd.Price = p.Price;
            prd.Details = p.Details;
            prd.StockAmount = p.StockAmount;
            prd.CategoryId = p.CategoryId;
            prd.Enabled = p.Enabled;
            return prd;
        }
        private static SellerProductUpdateDTO ProductDetailToDTO(Product product)
        {
            return new SellerProductUpdateDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Details = product.Details,
                StockAmount = product.StockAmount,
                CategoryId = product.CategoryId,
                Enabled = product.Enabled,
                ImageList = product.ProductImages.Select(i => i.Url ?? "").Where(url => url != "").ToList()
            };
        }
        private static Product ProductCreateToDTO(SellerProductCreateDTO p)
        {
            var prd = new Product();

            prd.Name = p.Name;
            prd.Price = p.Price;
            prd.Details = p.Details;
            prd.StockAmount = p.StockAmount;
            prd.CategoryId = p.CategoryId;
            prd.SellerId = p.SellerId;
            prd.Enabled = p.Enabled;
            return prd;

        }

    }
}
