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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserService;

        public UserController(IUserRepository UserService)
        {
            _UserService = UserService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var User = await _UserService.GetAllAsync();

            var UserDTO = new List<UserDTO>();

            foreach (var item in User)
            {
                UserDTO.Add(UseroDTO(item));
            }

            return Ok(UserDTO);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _UserService.FindAsync(id);

            if (item == null)
            {
                return NotFound(); // 404
            }
            return Ok(UseroDTO(item)); // 200
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(User user)
        {
            await _UserService.AddAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, UseroDTO(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var item = await _UserService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _UserService.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var item = await _UserService.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await _UserService.DeleteAsync(item);
            return NoContent();
        }
        private static UserDTO UseroDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Enabled = user.Enabled,
                CreatedAt = user.CreatedAt,
                RoleId = user.RoleId
            };
        }
    }
}











