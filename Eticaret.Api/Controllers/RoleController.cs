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
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleService;

        public RoleController(IRoleRepository roleService)
        {
            _roleService = roleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Role = await _roleService.GetAllAsync();

            var RoleDTO = new List<RoleDTO>();

            foreach (var item in Role)
            {
                RoleDTO.Add(RoleoDTO(item));
            }

            return Ok(RoleDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _roleService.FindAsync(id);

            if (item == null)
            {
                return NotFound(); // 404
            }
            return Ok(RoleoDTO(item)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Role Role)
        {
            await _roleService.AddAsync(Role);
            return CreatedAtAction(nameof(Get), new { id = Role.Id }, RoleoDTO(Role));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, Role Role)
        {
            if (id != Role.Id)
            {
                return BadRequest();
            }

            var item = await _roleService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _roleService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, Role Role)
        {
            if (id != Role.Id)
            {
                return BadRequest();
            }

            var item = await _roleService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _roleService.DeleteAsync(item);
            return NoContent();
        }
        private static RoleDTO RoleoDTO(Role Role)
        {
            return new RoleDTO
            {
                Id = Role.Id,
                Name = Role.Name,
                CreatedAt = Role.CreatedAt
            };
        }
    }
}











