using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Eticaret.Dto;
using System.Text.Json;
using Eticaret.Web.Mvc.Constants;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class AccountController : AppController
    {
        private readonly HttpClient _httpClient;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            var userAccount = new RegisterDTO()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password
            };

            var response = await _httpClient.PostAsJsonAsync("Account/register", userAccount);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Login));
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

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            var userAccount = new LoginDTO()
            {
                Email = user.Email,
                Password = user.Password
            };

            var response = await _httpClient.PostAsJsonAsync("Account/login", userAccount);

            if (response.IsSuccessStatusCode)
            {
                var tokenResponse = await response.Content.ReadAsStringAsync();

                if (tokenResponse != null)
                {
                    SetUserCookie(tokenResponse);

                    return RedirectToAction(nameof(Index), "Home");
                }

                ModelState.AddModelError("", "Geçersiz kullanıcı adı veya şifre");
            }

            return View(user);
        }

        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete(JWTSettings.TOKEN_NAME);
            //await _httpClient.PostAsync("Auth/logout", null);

            return RedirectToAction(nameof(Login));
        }

        private void SetUserCookie(string tokenResponse)
        {
            var jsonDoc = JsonDocument.Parse(tokenResponse);
            var token = jsonDoc.RootElement.GetProperty(JWTSettings.TOKEN_NAME).GetString();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Secure = true,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            if (token != null)
            {
                Response.Cookies.Append(JWTSettings.TOKEN_NAME, token, cookieOptions);
            }
        }
    }
}
