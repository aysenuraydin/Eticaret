using System.Data.Common;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("~/api/[controller]")]
    public class AdminProductCommentController : ControllerBase
    {
        private readonly IProductCommentRepository _productCommentRepo;

        public AdminProductCommentController(IProductCommentRepository productCommentRepo)
        {
            _productCommentRepo = productCommentRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductComments()
        {
            var products = (await _productCommentRepo.GetAllIncludeAsync(
                                   p => p.UserFk!,
                                   p => p.ProductFk!
                                  ))
                                  .OrderByDescending(p => p.CreatedAt)
                                  .Select(p => ProductCommentListToDTO(p))
                                  .ToList();

            if (products == null) return NotFound();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null) return NotFound();

            var product = (await _productCommentRepo.GetIdAllIncludeFilterAsync(
                          p => p.Id == id,
                          p => p.ProductFk!,
                          p => p.UserFk!
                         )).FirstOrDefault();


            if (product == null) return NotFound();
            return Ok(ProductCommentListToDTO(product));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(AdminProductCommentUpdateDTO p)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var prd = await _productCommentRepo.GetAsync(i => i.Id == p.Id);

            if (prd == null) return NotFound();

            try
            {
                await _productCommentRepo.UpdateAsync(ProductCommentApproveToDTO(p, prd));
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

            var prd = await _productCommentRepo.GetAsync(i => i.Id == id);

            if (prd == null) return NotFound();

            try
            {
                await _productCommentRepo.DeleteAsync(prd);
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


