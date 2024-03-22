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
    public class ProductCommentController : ControllerBase
    {
        private readonly IProductCommentRepository _productCommentService;

        public ProductCommentController(IProductCommentRepository productCommentService)
        {
            _productCommentService = productCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productCommentService.GetAllAsync();

            var ProductCommentsDTO = new List<ProductCommentDTO>();

            foreach (var item in products)
            {
                ProductCommentsDTO.Add(ProductCommentToDTO(item));
            }

            return Ok(ProductCommentsDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var comment = await _productCommentService.FindAsync(id);

            if (comment == null)
            {
                return NotFound(); // 404
            }
            return Ok(ProductCommentToDTO(comment)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductComment productComment)
        {
            await _productCommentService.AddAsync(productComment);
            return CreatedAtAction(nameof(GetProduct), new { id = productComment.Id }, ProductCommentToDTO(productComment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(int id, ProductComment productComment)
        {
            if (id != productComment.Id)
            {
                return BadRequest();
            }

            var item = await _productCommentService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _productCommentService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, ProductComment productComment)
        {
            if (id != productComment.Id)
            {
                return BadRequest();
            }

            var item = await _productCommentService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _productCommentService.DeleteAsync(item);
            return NoContent();
        }
        private static ProductCommentDTO ProductCommentToDTO(ProductComment comment)
        {
            return new ProductCommentDTO
            {
                Id = comment.Id,
                Text = comment.Text,
                StarCount = comment.StarCount,
                IsConfirmed = comment.IsConfirmed,
                CreatedAt = comment.CreatedAt,
                UserId = comment.UserId,
                ProductId = comment.ProductId
            };
        }
    }
}







