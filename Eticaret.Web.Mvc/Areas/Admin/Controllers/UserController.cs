using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IActionResult> List()
        {
            var response = await _httpClient.GetAsync("AdminUser");

            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<AdminUserListDTO>>() ?? new List<AdminUserListDTO>();
                return View(users);
            }

            return View();
        }

        public async Task<IActionResult> Approve(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminUser/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    AdminUserListDTO user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new();

                    return View(user);
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(AdminUserListDTO user)
        {
            var u = new AdminUserUpdateDTO()
            {
                Id = user.Id,
                Enabled = user.Enabled
            };

            var response = await _httpClient.PutAsJsonAsync($"AdminUser/{user.Id}", u);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(List));
            }

            TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminUser/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    AdminUserListDTO user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new();

                    return View(user);
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, User? user)
        {
            var response = await _httpClient.DeleteAsync($"AdminUser/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(List));

            TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";

            return RedirectToAction(nameof(List));
        }
    }
}
















