using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Authorize]
    [Route("api/[controller]")]
    public class AdminRoleController : ControllerBase
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AdminRoleController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _roleManager.Roles
                                .Include(i => i.Users)
                                .Select(i => RolesListDTO(i))
                                .ToListAsync();

            return Ok(roles);
        }

        [HttpGet("Users")]
        public async Task<IActionResult> GetRolesWithUsers()
        {
            var roles = await _roleManager.Roles
                                .Include(i => i.Users)
                                .Select(i => RolesListWithUserDTO(i))
                                .ToListAsync();

            return Ok(roles);
        }

        [HttpPut("Users/{userId}")]
        public async Task<IActionResult> UpdateUserRole(int? userId, RoleUpdateDTO roleId)
        {
            if (userId == null) return BadRequest(new { message = "UserId is required." });

            var user = await _userManager.FindByIdAsync(userId.ToString()!);

            if (user == null)
            {
                return NotFound(new { message = "User not found." });
            }

            user.RoleId = roleId.Id;
            user.SecurityStamp = Guid.NewGuid().ToString();

            if (string.IsNullOrEmpty(user.UserName))
            {
                user.UserName = user.Email?.Split("@")[0];
            }

            try
            {
                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Failed to update user role." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

            return Ok(user);
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateRole(int? id, RoleUpdateDTO role)
        {
            if (id == null) return NotFound();

            var r = await _roleManager.FindByIdAsync(id.ToString()!);

            if (r == null) return NotFound(new { message = "Role not found." });

            r.Name = role.Name;

            try
            {
                var result = await _roleManager.UpdateAsync(r);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

            return Ok(r);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateRole(RoleUpdateDTO role)
        {
            if (role == null) return NotFound();

            Role r = new() { Name = role.Name!.ToLower(), NormalizedName = role.Name!.ToUpper() };

            var result = await _roleManager.CreateAsync(r);

            if (result.Succeeded)
            {
                return StatusCode(201);
            }

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int? id)
        {
            if (id == null) return NotFound();

            var role = await _roleManager.FindByIdAsync(id.ToString()!);

            if (role == null) return NotFound();

            //bu roller silinemez
            if (role.Name == "buyer" || role.Name == "seller") return NoContent();

            // Kullanıcıların rolünü güncelle
            var usersWithRole = await _userManager.Users
                                       .Where(x => x.RoleId == id)
                                       .ToListAsync();

            foreach (var user in usersWithRole)
            {
                user.RoleId = 2; // Yeni rol ID'si
                await _userManager.UpdateAsync(user);
            }

            try
            {
                await _roleManager.DeleteAsync(role);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static RoleListWithUserDTO RolesListWithUserDTO(Role c)
        {
            RoleListWithUserDTO entity = new();

            if (c != null)
            {
                entity.Id = c.Id;
                entity.Name = c.Name ?? "";
                entity.Users = c.Users.Select(i => new UserRole()
                {
                    Id = i.Id,
                    FullName = $"{i.FirstName} {i.LastName}",
                }).ToList();
            }

            return entity;
        }

        private static RoleUpdateDTO RolesListDTO(Role c)
        {
            RoleUpdateDTO entity = new();

            if (c != null)
            {
                entity.Id = c.Id;
                entity.Name = c.Name ?? "";
            }

            return entity;
        }
    }
}
