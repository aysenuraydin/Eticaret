
using System.Text;
using System.Text.Json;
using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class RoleController : Controller
    {
        private readonly IRoleRepository _roleService;
        private readonly IUserRepository _userService;
        private readonly HttpClient _httpClient;
        public RoleController(IRoleRepository roleService, IUserRepository userService, IHttpClientFactory httpClientFactory)
        {
            _roleService = roleService;
            _userService = userService;

            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        public async Task<IActionResult> Index()
        {
            using (var response = await _httpClient.GetAsync("AdminRole/Users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var roles = await response.Content.ReadFromJsonAsync<List<RoleListWithUserDTO>>() ?? new List<RoleListWithUserDTO>();

                    var roleResponse = await _httpClient.GetAsync("AdminRole/Users");
                    if (roleResponse.IsSuccessStatusCode)
                    {
                        var rolesList = await roleResponse.Content.ReadFromJsonAsync<List<RoleUpdateDTO>>() ?? new List<RoleUpdateDTO>();
                        ViewBag.Roles = new SelectList(rolesList, "Id", "Name");
                    }
                    return View(roles);
                }
                else
                {
                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                    return View("Error");
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return View("Error");
            try
            {
                var role = new RoleUpdateDTO { Name = roleName };
                var content = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("AdminRole/Create", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), "Role");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoleName(int? id, string roleName)
        {
            if (id == null) return View("Error");

            var roleUpdateDTO = new RoleUpdateDTO { Name = roleName };
            var content = new StringContent(JsonSerializer.Serialize(roleUpdateDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"AdminRole/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserRole(int? userId, int roleId)
        {
            if (userId == null) return View("Error");

            var roleUpdateDTO = new RoleUpdateDTO { Id = roleId };
            var content = new StringContent(JsonSerializer.Serialize(roleUpdateDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"AdminRole/Users/{userId}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View("Error");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(int? id)
        {
            if (id == null) return View("Error");
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminRole/{id}");

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index), "Role");
                else
                    return View("Error");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            };
        }
    }
}



