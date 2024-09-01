using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Eticaret.Api.Constants;
using Eticaret.Domain;
using Eticaret.Dto;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Eticaret.Api.Controllers
{
    public class AccountController : AppController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(RegisterDTO model)
        {
            if (model == null) return NotFound();

            var user = new User
            {
                UserName = model.Email.Split("@")[0],
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email
            };

            if (user.Email == "admin@admin.com") user.RoleId = 3;
            else if (user.Email == "seller@seller.com") user.RoleId = 1;

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var role = await _roleManager.Roles.FirstOrDefaultAsync(i => i.Id == user.RoleId);

                if (role != null)
                {
                    // Rol bulundu, kullanıcıya rol atama işlemi gerçekleştirilebilir.
                    await _userManager.AddToRoleAsync(user, role.Name!);
                }
                else
                {
                    await _roleManager.CreateAsync(new Role { Name = role?.Name!.ToLower(), NormalizedName = role?.Name!.ToUpper() });
                }

                return StatusCode(201);
            }

            return BadRequest(result.Errors);
        }

        [Authorize]
        [HttpGet("{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return NotFound(new { message = "Email hatalı" });

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginDTO model)
        {
            if (model == null) return BadRequest();

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null) return BadRequest(new { message = "Email hatalı" });

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);

                var token = await GenerateJwtToken(user);

                return Ok(new { token });
            }

            return Unauthorized();
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> LogoutUser()
        {
            var user = await _signInManager.UserManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized(new { message = "Oturum açmış bir kullanıcı bulunamadı" });
            }

            await _signInManager.SignOutAsync();

            return Ok(new { message = "Oturum başarıyla sonlandırıldı" });
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            var secret = _configuration[ApplicationSettings.CONFIG_SECRET_KEY] //!
                ?? throw new Exception("AppSettings Secret key not found");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (JwtClaimTypes.Subject, user.Id.ToString()),
                    new (JwtClaimTypes.Role, userRoles[0]),
                    new (JwtClaimTypes.GivenName, user.FirstName),
                    new (JwtClaimTypes.NickName, user.UserName!),
                    new (JwtClaimTypes.Email, user.Email!),
                    new (JwtClaimTypes.JwtId, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token); ;
        }
    }
}
