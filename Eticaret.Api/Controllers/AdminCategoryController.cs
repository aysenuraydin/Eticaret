using System.Drawing;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminCategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryService;
        public AdminCategoryController(ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var products = await _categoryService.GetAllIncludeAsync(
                                        i => i.Products
                                        );

            var prd = products
                         .Select(p => CategoriesListToDTO(p));

            return Ok(prd);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int? id)
        {
            if (id == null) return NotFound();

            var product = await _categoryService.GetIdAllIncludeFilterAsync(
                                       i => i.Id == id,
                                       i => i.Products
                                      );


            if (product == null) return NotFound();

            var prd = product.Select(p => CategoriesListToDTO(p))
                        .FirstOrDefault();
            return Ok(prd);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(AdminCategoryCreateDTO entity)
        {
            try
            {
                var p = CategoriesCreateToDTO(entity);
                await _categoryService.AddAsync(p);
                return CreatedAtAction(nameof(GetCategory), new { id = p.Id }, p);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(AdminCategoryUpdateDTO p)
        {
            var ctgry = await _categoryService.GetAsync(i => i.Id == p.Id);

            if (ctgry == null) return NotFound();

            try
            {
                await _categoryService.UpdateAsync(CategoriesUpdateToDTO(p, ctgry));
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(ctgry);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null) return NotFound();

            var prd = await _categoryService.GetAsync(i => i.Id == id);

            if (prd == null) return NotFound();

            try
            {
                await _categoryService.DeleteAsync(prd);
            }
            catch (Exception)
            {
                return NotFound();
            }
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

