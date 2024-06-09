
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }
        private readonly HttpClient _httpClient;

        public async Task<IActionResult> Details()
        {
            using (var response = await _httpClient.GetAsync("Profile"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new AdminUserListDTO() ?? new AdminUserListDTO();

                    return View(user);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                    return View("Error");
                }
            }
        }
        public async Task<IActionResult> Edit()
        {
            using (var response = await _httpClient.GetAsync("Profile"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new AdminUserListDTO() ?? new AdminUserListDTO();

                    if (user != null)
                    {
                        RegisterViewModel editUser = new()
                        {
                            FirstName = user.FirstName!,
                            LastName = user.LastName!,
                            Email = user.Email!
                        };
                        return View(editUser);
                    }
                }
                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var u = new UserUpdateDTO()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Password = user.Password,
                        Email = user.Email,
                    };

                    var json = JsonSerializer.Serialize(u);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"Profile", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Details));
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Hata Oluştu!");
                }
            }
            return View(user);
        }
        public async Task<IActionResult> MyOrders()
        {
            using (var response = await _httpClient.GetAsync($"Order"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadFromJsonAsync<List<OrderDetailDTO>>();

                    if (orders != null) return View(orders);
                }
                else
                {
                    return View(new List<OrderDetailDTO>());
                }
            }
            return RedirectToAction(nameof(Index), "Home");

        }
    }
}



