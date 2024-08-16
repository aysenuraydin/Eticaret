using System.Security.Claims;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCommentController : ControllerBase
    {
        private readonly IProductCommentRepository _productCommentRepo;
        public ProductCommentController(
            IProductCommentRepository productCommentRepo
            )
        {
            _productCommentRepo = productCommentRepo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductComment(int? id)
        {
            if (id == null) return NotFound();

            var comment = (await _productCommentRepo.GetIdAllIncludeFilterAsync(
                                p => p.ProductId == id && p.IsConfirmed == true,
                                p => p.UserFk!
                                ))
                                .OrderByDescending(p => p.CreatedAt)
                                .Select(p => ProductCommentListToDTO(p))
                                .ToList();

            return Ok(comment);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProductComment(ProductCommentCreateDTO entity)
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                var p = ProductCreatToDTO(entity);

                p.UserId = userId;

                await _productCommentRepo.AddAsync(p);

                return CreatedAtAction(nameof(GetProductComment), new { id = p.Id }, p);
            }

            return NotFound();
        }

        private static ProductCommentListDTO ProductCommentListToDTO(ProductComment p)
        {
            return new ProductCommentListDTO
            {
                Text = p.Text,
                StarCount = p.StarCount,
                UserName = $"{p.UserFk?.FirstName ?? string.Empty} {p.UserFk?.LastName ?? string.Empty}".Trim(),
            };
        }

        private static ProductComment ProductCreatToDTO(ProductCommentCreateDTO p)
        {
            return new ProductComment
            {
                Text = p.Text,
                StarCount = p.StarCount,
                ProductId = p.ProductId
            };
        }
    }
}