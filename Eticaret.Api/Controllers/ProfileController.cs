using System.Security.Claims;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private IPasswordValidator<User> _passwordValidator;
        private IPasswordHasher<User> _passwordHasher;
        public ProfileController(UserManager<User> userManager, IPasswordValidator<User> passValidator, IPasswordHasher<User> passHasher)
        {
            _userManager = userManager;
            _passwordValidator = passValidator;
            _passwordHasher = passHasher;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoggedUser()
        {
            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                var user = await _userManager.Users
                                .Include(p => p.RoleFk)
                                .Include(p => p.CartItems)
                                .Include(p => p.ProductComments)
                                .Include(p => p.Orders)
                                .FirstOrDefaultAsync(p => p.Id == userId);

                if (user == null) return NotFound();

                return Ok(UserListToDTO(user));
            }
            return BadRequest("User ID is not valid.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO p)
        {
            if (p == null) return NotFound();

            if (int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());

                if (user == null) return NotFound();
                User updatedUser = UserUpdateToDTO(p, user);
                IdentityResult? validPass = null;

                if (!string.IsNullOrEmpty(p.Password)) //parolaya güncelleme yapılmış mı?
                {
                    //parola validate işlemine uygun mu
                    validPass = await _passwordValidator.ValidateAsync(_userManager, updatedUser, p.Password);

                    if (validPass.Succeeded)//uygunsa parolayı güncelle
                    {
                        updatedUser.PasswordHash = _passwordHasher.HashPassword(updatedUser, p.Password);
                    }
                    else
                    {
                        foreach (var item in validPass.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }

                if (validPass!.Succeeded)//diğer inputlar güncellemeye uygun mu
                {
                    var result = await _userManager.UpdateAsync(updatedUser);

                    if (result.Succeeded) return Ok(p);
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        private static AdminUserListDTO UserListToDTO(User u)
        {
            return new AdminUserListDTO
            {
                Id = u.Id,
                Email = u.Email,
                FullName = $"{u.FirstName} {u.LastName}",
                FirstName = u.FirstName,
                LastName = u.LastName,
                Enabled = u.Enabled,
                CreatedAt = u.CreatedAt.ToString("dd.MM.yyyy"),
                RoleName = u.RoleFk.Name,
                CartItemCount = u.CartItems.Count,
                ProductCommentCount = u.ProductComments.Count,
                OrderCount = u.Orders.Count
            };
        }

        private static User UserUpdateToDTO(UserUpdateDTO user, User u)
        {
            u.FirstName = user.FirstName ?? "";
            u.LastName = user.LastName ?? "";
            u.Email = user.Email ?? "";
            u.PasswordHash = user.Password ?? "";

            return u;
        }
    }
}
