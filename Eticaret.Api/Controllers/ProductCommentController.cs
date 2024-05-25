using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCommentController : ControllerBase
    {
        private readonly IProductCommentRepository _productCommentService;
        public ProductCommentController(
            IProductCommentRepository productCommentService
            )
        {
            _productCommentService = productCommentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null) return NotFound();

            var comment = await _productCommentService.GetIdAllIncludeFilterAsync(
                          p => p.ProductId == id && p.IsConfirmed == true,
                          p => p.UserFk!
                         );


            if (comment == null) return NotFound();

            var cmnt = comment
                        .OrderByDescending(p => p.CreatedAt)
                        .Select(p => ProductCommentListToDTO(p))
                        .ToList();
            return Ok(cmnt);
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
    }
}