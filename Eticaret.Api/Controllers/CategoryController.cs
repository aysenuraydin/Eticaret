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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryService;

        public CategoryController(
        ICategoryRepository categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            var CategoryDTO = new List<CategoryDTO>();

            foreach (var c in categories)
            {
                CategoryDTO.Add(CategoryToDTO(c));
            }

            return Ok(CategoryDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _categoryService.FindAsync(id);

            if (comment == null)
            {
                return NotFound(); // 404
            }
            return Ok(CategoryToDTO(comment)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Category category)
        {
            await _categoryService.AddAsync(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, CategoryToDTO(category));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var ctgry = await _categoryService.FindAsync(id);

            if (ctgry == null)
            {
                return NotFound();
            }

            await _categoryService.UpdateAsync(ctgry);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var img = await _categoryService.FindAsync(id);

            if (img == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteAsync(img);
            return NoContent();
        }
        private static CategoryDTO CategoryToDTO(Category c)
        {
            return new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Color = c.Color,
                IconCssClass = c.IconCssClass,
                CreatedAt = c.CreatedAt
            };
        }
    }
}









