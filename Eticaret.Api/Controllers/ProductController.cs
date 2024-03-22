using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Product2Controller : ControllerBase
    {
        private readonly IProductRepository _productService;

        public Product2Controller(IProductRepository productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productService.GetAllAsync();

            var productsDTO = new List<ProductDTO>();

            foreach (var p in products)
            {
                productsDTO.Add(ProductToDTO(p));
            }

            return Ok(productsDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.FindAsync(id);

            if (product == null)
            {
                return NotFound(); // 404
            }
            return Ok(ProductToDTO(product)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, ProductToDTO(product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, Product p)
        {
            if (id != p.Id)
            {
                return BadRequest();
            }

            var product = await _productService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.UpdateAsync(p);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Product p)
        {
            if (id != p.Id)
            {
                return BadRequest();
            }

            var product = await _productService.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(p);
            return NoContent();
        }
        private static ProductDTO ProductToDTO(Product p)
        {
            return new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Details = p.Details,
                StockAmount = p.StockAmount,
                CreatedAt = p.CreatedAt,
                IsConfirmed = p.IsConfirmed,
                Enabled = p.Enabled,
                CategoryId = p.CategoryId,
                SellerId = p.CategoryId,
            };
        }
    }
}






