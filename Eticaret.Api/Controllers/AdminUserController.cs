using Eticaret.Domain.Constants;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminUserController : AppController
    {
        private readonly UserManager<User> _userManager;
        public AdminUserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users
                            .Include(p => p.RoleFk)
                            .Include(p => p.CartItems)
                            .Include(p => p.ProductComments)
                            .Include(p => p.Orders)
                            .OrderByDescending(p => p.CreatedAt)
                            .Select(p => UserListToDTO(p))
                            .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int? id)
        {
            if (id == null) return BadRequest(new { message = "UserId is required." });

            var user = await _userManager.Users
                            .Include(p => p.RoleFk)
                            .Include(p => p.CartItems)
                            .Include(p => p.ProductComments)
                            .Include(p => p.Orders)
                            .FirstOrDefaultAsync(p => p.Id == id);

            if (user == null) return NotFound(new { message = "User is not found." });

            return Ok(UserListToDTO(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(AdminUserUpdateDTO p)
        {
            if (p == null) return NotFound(new { message = "Eksik bilgi girdiniz" });

            var user = await _userManager.FindByIdAsync(p.Id.ToString()!);

            if (user == null) return NotFound(new { message = "User is not found." });

            try
            {
                await _userManager.UpdateAsync(UserApproveToDTO(p, user));
            }
            catch (Exception)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int? id)
        {
            if (id == null) return NotFound();

            var user = await _userManager.FindByIdAsync(id.ToString()!);

            if (user == null) return NotFound();

            try
            {
                await _userManager.DeleteAsync(user);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        private static AdminUserListDTO UserListToDTO(User u)
        {
            return new AdminUserListDTO
            {
                Id = u.Id,
                Email = u.Email,
                FullName = $"{u.FirstName} {u.LastName}",
                FirstName = u.FirstName,
                LastName = u.FirstName,
                Enabled = u.Enabled,
                CreatedAt = u.CreatedAt.ToString("dd.MM.yyyy"),
                RoleName = u.RoleFk.Name,
                CartItemCount = u.CartItems.Count,
                ProductCommentCount = u.ProductComments.Count,
                OrderCount = u.Orders.Count
            };
        }

        private static User UserApproveToDTO(AdminUserUpdateDTO p, User u)
        {
            u.Enabled = p.Enabled;

            return u;
        }
    }
}
