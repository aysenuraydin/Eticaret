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
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        public async Task<IActionResult> List()
        {
            try
            {
                using (var response = await _httpClient.GetAsync("AdminUser"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var users = await response.Content.ReadFromJsonAsync<List<AdminUserListDTO>>() ?? new List<AdminUserListDTO>();

                        return View(users);
                    }

                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View(new List<AdminUserListDTO>());
        }

        public async Task<IActionResult> Approve(int id)
        {
            try
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
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(AdminUserListDTO user)
        {
            try
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

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
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
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, User? user)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminUser/{id}");

                if (response.IsSuccessStatusCode) return RedirectToAction(nameof(List));

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return RedirectToAction(nameof(List));
        }
    }
}
















