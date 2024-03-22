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
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageService;

        public ProductImageController(IProductImageRepository productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productImageService.GetAllAsync();

            var ProductImagesDTO = new List<ProductImageDTO>();

            foreach (var p in products)
            {
                ProductImagesDTO.Add(ProductImageToDTO(p));
            }

            return Ok(ProductImagesDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productImageService.FindAsync(id);

            if (product == null)
            {
                return NotFound(); // 404
            }
            return Ok(ProductImageToDTO(product)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductImage productImage)
        {
            await _productImageService.AddAsync(productImage);
            return CreatedAtAction(nameof(GetProduct), new { id = productImage.Id }, ProductImageToDTO(productImage));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, ProductImage productImage)
        {
            if (id != productImage.Id)
            {
                return BadRequest();
            }

            var img = await _productImageService.FindAsync(id);

            if (img == null)
            {
                return NotFound();
            }

            await _productImageService.UpdateAsync(img);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, ProductImage productImage)
        {
            if (id != productImage.Id)
            {
                return BadRequest();
            }

            var img = await _productImageService.FindAsync(id);

            if (img == null)
            {
                return NotFound();
            }

            await _productImageService.DeleteAsync(img);
            return NoContent();
        }
        private static ProductImageDTO ProductImageToDTO(ProductImage p)
        {
            return new ProductImageDTO
            {
                Id = p.Id,
                Url = p.Url,
                CreatedAt = p.CreatedAt,
                ProductId = p.ProductId,
                SellerId = p.SellerId,
            };
        }
    }
}






