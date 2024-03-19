using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Extensions.Logging;

namespace Eticaret.Web.Mvc.Controllers
{
    // [Authorize]
    public class AuthController : Controller
    {
        private readonly IUserRepository _userService;

        public AuthController(IUserRepository userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userAcount = new User()
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password
                    };

                    _userService.Add(userAcount);
                    return RedirectToAction(nameof(Index), "Home");
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
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var isUser = _userService.GetAll().Where(u => u.Enabled)
                            .FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);


                    if (isUser != null)
                    {
                        var userClaims = new List<Claim>
                            {
                                new Claim(ClaimTypes.NameIdentifier, isUser.Id.ToString()),
                                new Claim(ClaimTypes.Name, (isUser.FirstName +" "+isUser.LastName) ?? ""),
                                new Claim(ClaimTypes.Email, isUser.Email ?? ""),
                                new Claim(ClaimTypes.GivenName, isUser.Email ?? ""),
                            };

                        if (isUser.RoleId == 3)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                        }
                        else if (isUser.RoleId == 2)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, "buyer"));
                        }
                        else if (isUser.RoleId == 1)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, "seller"));
                        }

                        var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                        var authProperties = new AuthenticationProperties
                        {
                            IsPersistent = false
                        };

                        if (user.RememberMe)
                        {
                            authProperties = new AuthenticationProperties
                            {
                                IsPersistent = true
                            };
                        }
                        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity), authProperties
                        );

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
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}