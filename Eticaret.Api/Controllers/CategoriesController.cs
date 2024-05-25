using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryService;
        public CategoriesController(
            ICategoryRepository categoryService
            )
        {
            _categoryService = categoryService;
        }
        [HttpGet]

        public async Task<IActionResult> GetProducts()
        {
            var products = await _categoryService.GetAllAsync();

            var prd = products
                         .Select(p => CategoriesListToDTO(p));

            return Ok(prd);
        }


        private static CategoryListDTO CategoriesListToDTO(Category c)
        {
            CategoryListDTO entity = new();
            if (c != null)
            {
                entity.Id = c.Id;
                entity.Name = c.Name ?? "";

            }
            return entity;
        }
    }
}
