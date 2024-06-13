using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("~/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoriesController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = (await _categoryRepo.GetAllAsync())
                                 .Select(p => CategoriesListToDTO(p))
                                 .ToList();

            return Ok(products);
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
