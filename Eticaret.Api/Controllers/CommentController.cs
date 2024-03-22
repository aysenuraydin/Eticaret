using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Models.DTO;
using Eticaret.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IProductCommentRepository _productCommentService;

        public CommentController(
        IProductCommentRepository productCommentService)
        {
            _productCommentService = productCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _productCommentService.GetAllAsync();

            var ProductCommentDTO = new List<ProductCommentDTO>();

            foreach (var p in comments)
            {
                ProductCommentDTO.Add(ProductCommentToDTO(p));
            }

            return Ok(ProductCommentDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _productCommentService.FindAsync(id);

            if (comment == null)
            {
                return NotFound(); // 404
            }
            return Ok(ProductCommentToDTO(comment)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductComment comment)
        {
            await _productCommentService.AddAsync(comment);
            return CreatedAtAction(nameof(Get), new { id = comment.Id }, ProductCommentToDTO(comment));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ProductImage productImage)
        {
            if (id != productImage.Id)
            {
                return BadRequest();
            }

            var img = await _productCommentService.FindAsync(id);

            if (img == null)
            {
                return NotFound();
            }

            await _productCommentService.UpdateAsync(img);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, ProductImage productImage)
        {
            if (id != productImage.Id)
            {
                return BadRequest();
            }

            var img = await _productCommentService.FindAsync(id);

            if (img == null)
            {
                return NotFound();
            }

            await _productCommentService.DeleteAsync(img);
            return NoContent();
        }
        private static ProductCommentDTO ProductCommentToDTO(ProductComment p)
        {
            return new ProductCommentDTO
            {
                Id = p.Id,
                Text = p.Text,
                StarCount = p.StarCount,
                IsConfirmed = p.IsConfirmed,
                CreatedAt = p.CreatedAt,
                UserId = p.UserId,
                ProductId = p.ProductId
            };
        }
    }
}









