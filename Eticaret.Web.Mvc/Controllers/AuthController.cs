using System.Security.Claims;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Dto;
using System.Text.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        public AuthController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userAccount = new RegisterDTO()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password
                    };

                    var json = JsonSerializer.Serialize(userAccount);

                    var response = await _httpClient.PostAsync("Auth/register", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index), "Home");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userAccount = new LoginDTO()
                    {
                        Email = user.Email,
                        Password = user.Password
                    };

                    var json = JsonSerializer.Serialize(userAccount);
                    var response = await _httpClient.PostAsync("Auth/login", new StringContent(json, Encoding.UTF8, "application/json"));

                    if (response.IsSuccessStatusCode)
                    {
                        var tokenResponse = await response.Content.ReadAsStringAsync();
                        if (tokenResponse != null)
                        {
                            SetUserCookie(tokenResponse);
                            return RedirectToAction(nameof(Index), "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
                        }
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(user);
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            if (!User.Identity!.IsAuthenticated)
            {
                return RedirectToAction(nameof(Login), "Home");
            }

            await _httpClient.PostAsync("Auth/logout", null);

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            Response.Cookies.Delete("token");//!
            return RedirectToAction(nameof(Index), "Home");
        }
        private void SetUserCookie(string tokenResponse)
        {
            var jsonDoc = JsonDocument.Parse(tokenResponse);
            var token = jsonDoc.RootElement.GetProperty("token").GetString();

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null)
            {
                throw new SecurityTokenMalformedException("Invalid JWT token.");
            }

            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.NameId)?.Value ?? ""),
                new Claim(ClaimTypes.Name, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value ?? ""),
                new Claim(ClaimTypes.Email, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value ?? ""),
                new Claim(ClaimTypes.GivenName, jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.GivenName)?.Value ?? ""),
                new Claim(ClaimTypes.Role, jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value ?? "")
            };

            var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = false
            };

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties).Wait();

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };

            Response.Cookies.Append("token", tokenHandler.WriteToken(jwtToken), cookieOptions);//!
        }

    }
}
