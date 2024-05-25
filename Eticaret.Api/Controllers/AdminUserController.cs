using System.Data.Common;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminUserController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public AdminUserController(IUserRepository userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllIncludeAsync(
                                        p => p.RoleFk,
                                        p => p.CartItems,
                                        p => p.ProductComments,
                                        p => p.Orders
                                       );

            var user = users
                     .OrderByDescending(p => p.CreatedAt)
                     .Select(p => UserListToDTO(p))
                     .ToList();

            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int? id)
        {
            if (id == null) return NotFound();

            var user = await _userService.GetIdAllIncludeFilterAsync(
                                            p => p.Id == id,
                                            p => p.RoleFk,
                                            p => p.CartItems,
                                            p => p.ProductComments,
                                            p => p.Orders
                                         );

            if (user == null) return NotFound();

            var u = user.Select(p => UserListToDTO(p))
                        .FirstOrDefault();
            return Ok(u);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(AdminUserUpdateDTO p)
        {
            var user = await _userService.GetAsync(i => i.Id == p.Id);

            if (user == null) return NotFound();

            try
            {
                await _userService.UpdateAsync(UserApproveToDTO(p, user));
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

            var user = await _userService.GetAsync(i => i.Id == id);

            if (user == null) return NotFound();

            try
            {
                await _userService.DeleteAsync(user);
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

