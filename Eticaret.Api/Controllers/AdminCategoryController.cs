using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Api.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminCategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public AdminCategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var products = (await _categoryRepo.GetAllIncludeAsync(
                                i => i.Products
                                ))
                                .Select(p => CategoriesListToDTO(p))
                                .ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int? id)
        {
            if (id == null) return NotFound();

            var product = (await _categoryRepo.GetIdAllIncludeFilterAsync(
                                        i => i.Id == id,
                                        i => i.Products
                                        )).FirstOrDefault();


            if (product == null) return NotFound();
            return Ok(CategoriesListToDTO(product));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(AdminCategoryCreateDTO entity)
        {
            if (entity == null) return BadRequest();

            var p = CategoriesCreateToDTO(entity);
            await _categoryRepo.AddAsync(p);

            return CreatedAtAction(nameof(GetCategory), new { id = p.Id }, p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, AdminCategoryUpdateDTO category)
        {
            if (id != category.Id) return BadRequest();

            var ctgry = await _categoryRepo.GetAsync(i => i.Id == id);

            if (ctgry == null) return NotFound();

            await _categoryRepo.UpdateAsync(CategoriesUpdateToDTO(category, ctgry));

            return Ok(ctgry);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null) return NotFound();

            var prd = await _categoryRepo.GetAsync(i => i.Id == id);

            if (prd == null) return NotFound();

            await _categoryRepo.DeleteAsync(prd);

            return NoContent();
        }

        private static AdminCategoryListDTO CategoriesListToDTO(Category c)
        {
            return new AdminCategoryListDTO
            {
                Id = c.Id,
                Name = c.Name ?? "",
                Color = c.Color ?? "",
                Css = c.IconCssClass ?? "",
                CreatedAt = c.CreatedAt.ToString("dd.MM.yyyy"),
                ProductCount = c.Products.Count,
            };
        }

        private static Category CategoriesUpdateToDTO(AdminCategoryUpdateDTO p, Category c)
        {
            c.Name = p.Name ?? "";
            c.Color = p.Color ?? "";
            c.IconCssClass = p.Css ?? "";

            return c;
        }

        private static Category CategoriesCreateToDTO(AdminCategoryCreateDTO p)
        {
            return new Category()
            {
                Color = p.Color ?? "",
                Name = p.Name,
                IconCssClass = p.Css ?? ""
            };
        }
    }
}

