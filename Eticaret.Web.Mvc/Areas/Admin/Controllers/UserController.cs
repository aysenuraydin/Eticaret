

using System.Text;
using System.Text.Json;
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
            using (var response = await _httpClient.GetAsync("AdminUser"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var users = await response.Content.ReadFromJsonAsync<List<AdminUserListDTO>>() ?? new List<AdminUserListDTO>();
                    return View(users);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                    return View("Error");
                }
            }
        }
        public async Task<IActionResult> Approve(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminUser/{id}"))
            {
                AdminUserListDTO user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new();
                return View(user);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(User user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user);

                var response = await _httpClient.PutAsync($"AdminUser/{user.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var updateUser = await response.Content.ReadFromJsonAsync<AdminUserListDTO>();
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();

                    ViewBag.Error = error;
                    return View("Error");
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminUser/{id}"))
            {
                AdminUserListDTO user = await response.Content.ReadFromJsonAsync<AdminUserListDTO>() ?? new();
                return View(user);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, User? user)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminUser/{id}");

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(List));
                else
                    return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }


    }
}
















