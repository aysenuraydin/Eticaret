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
    public class AdminProductCommentController : ControllerBase
    {
        private readonly IProductCommentRepository _productCommentService;

        public AdminProductCommentController(IProductCommentRepository productCommentService)
        {
            _productCommentService = productCommentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductComments()
        {
            var products = await _productCommentService.GetAllIncludeAsync(
                                        p => p.UserFk!,
                                        p => p.ProductFk!
                                       );

            var prd = products
                     .OrderByDescending(p => p.CreatedAt)
                     .Select(p => ProductCommentListToDTO(p))
                     .ToList();

            return Ok(prd);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productCommentService.GetIdAllIncludeFilterAsync(
                          p => p.Id == id,
                          p => p.ProductFk!,
                          p => p.UserFk!
                         );


            if (product == null) return NotFound();

            var prd = product.Select(p => ProductCommentListToDTO(p))
                        .FirstOrDefault();
            return Ok(prd);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(AdminProductCommentUpdateDTO p)
        {
            var prd = await _productCommentService.GetAsync(i => i.Id == p.Id);

            if (prd == null) return NotFound();

            try
            {
                await _productCommentService.UpdateAsync(ProductCommentApproveToDTO(p, prd));
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(prd);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductComment(int? id)
        {
            if (id == null) return NotFound();

            var prd = await _productCommentService.GetAsync(i => i.Id == id);

            if (prd == null) return NotFound();

            try
            {
                await _productCommentService.DeleteAsync(prd);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }

        private static AdminProductCommentListDTO ProductCommentListToDTO(ProductComment p)
        {
            return new AdminProductCommentListDTO
            {
                Id = p.Id,
                Text = p.Text,
                StarCount = p.StarCount,
                IsConfirmed = p.IsConfirmed,
                CreatedAt = p.CreatedAt.ToString("dd.MM.yyyy"),
                UserName = $"{p.UserFk!.FirstName} {p.UserFk.LastName}",
                ProductName = p.ProductFk!.Name
            };
        }
        private static ProductComment ProductCommentApproveToDTO(AdminProductCommentUpdateDTO p, ProductComment c)
        {
            c.IsConfirmed = p.IsConfirmed;
            return c;
        }
    }
}


