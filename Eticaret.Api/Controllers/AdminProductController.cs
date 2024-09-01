using Eticaret.Domain.Constants;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminProductController : AppController
    {
        private readonly IProductRepository _productRepo;

        public AdminProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = (await _productRepo.GetAllIncludeAsync(
                                p => p.ProductImages,
                                p => p.ProductComments,
                                p => p.UserFk!,
                                p => p.CategoryFk!,
                                p => p.OrderItems,
                                p => p.CartItems
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
                                p => p.ProductImages,
                                p => p.ProductComments,
                                p => p.UserFk!,
                                p => p.CategoryFk!,
                                p => p.OrderItems,
                                p => p.CartItems
                                )).FirstOrDefault();

            if (product == null) return NotFound();

            return Ok(ProductListToDTO(product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(AdminProductUpdateDTO p)
        {
            if (p == null) return BadRequest();

            var prd = await _productRepo.GetAsync(i => i.Id == p.Id);

            if (prd == null) return NotFound();

            try
            {
                await _productRepo.UpdateAsync(ProductApproveToDTO(p, prd));
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

            var prd = await _productRepo.GetAsync(i => i.Id == id);

            if (prd == null) return NotFound();

            try
            {
                await _productRepo.DeleteAsync(prd);
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
                SellerName = $"{p.UserFk!.FirstName} {p.UserFk.LastName}",
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

