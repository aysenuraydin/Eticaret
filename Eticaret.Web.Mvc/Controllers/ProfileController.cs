using Eticaret.Dto;
using Eticaret.Web.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly HttpClient _httpClient;

        public ProfileController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IActionResult> Details()
        {
            using (var response = await _httpClient.GetAsync("Profile"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new AdminUserListDTO() ?? new AdminUserListDTO();

                    return View(user);
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }

            return View();
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
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegisterViewModel user)
        {
            if (!ModelState.IsValid) return View(user);

            var u = new UserUpdateDTO()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Email = user.Email,
            };

            var response = await _httpClient.PutAsJsonAsync($"Profile", u);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Details));
            }

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";

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

                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                }
            }

            return View();
        }
    }
}



