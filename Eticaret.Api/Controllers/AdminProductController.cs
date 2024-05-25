using System.Data.Common;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminProductController : ControllerBase
    {
        private readonly IProductRepository _productService;

        public AdminProductController(IProductRepository productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetAllIncludeAsync(
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

            var prd = product.Select(p => ProductListToDTO(p))
                        .FirstOrDefault();
            return Ok(prd);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(AdminProductUpdateDTO p)
        {
            var prd = await _productService.GetAsync(i => i.Id == p.Id);

            if (prd == null) return NotFound();

            try
            {
                await _productService.UpdateAsync(ProductApproveToDTO(p, prd));
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

        private static AdminProductListDTO ProductListToDTO(Product p)
        {
            return new AdminProductListDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrlList = p.ProductImages.Select(i => i.Url ?? "").Where(url => url != "").ToList()!,
                Details = p.Details,
                StockAmount = p.StockAmount,
                Enabled = p.Enabled,
                IsConfirmed = p.IsConfirmed,
                CategoryName = p.CategoryFk!.Name ?? "",
                CategoryColor = p.CategoryFk!.Color ?? "",
                SellerName = $"{p.SellerFk!.FirstName} {p.SellerFk.LastName}",
                CommentCount = p.ProductComments.Count,
                OrderCount = p.OrderItems.Count,
                CartCount = p.CartItems.Count,
                CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy"),
            };
        }
        private static Product ProductApproveToDTO(AdminProductUpdateDTO p, Product prd)
        {
            prd.IsConfirmed = p.IsConfirmed;
            return prd;
        }
    }
}

