using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    public class RoleController : AppController
    {
        private readonly HttpClient _httpClient;
        public RoleController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
        }
        public async Task<IActionResult> Index()
        {
            if (TempData["ErrorMessage"] != null) ViewBagMessage(TempData["ErrorMessage"].ToString());

            using (var response = await _httpClient.GetAsync("AdminRole/Users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var roles = await response.Content.ReadFromJsonAsync<List<RoleListWithUserDTO>>() ?? new List<RoleListWithUserDTO>();

                    var roleResponse = await _httpClient.GetAsync("AdminRole");

                    if (roleResponse.IsSuccessStatusCode)
                    {
                        var rolesList = await roleResponse.Content.ReadFromJsonAsync<List<RoleUpdateDTO>>() ?? new List<RoleUpdateDTO>();

                        ViewBag.Roles = new SelectList(rolesList, "Id", "Name");

                        return View(roles);
                    }
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                ViewBagMessage("Role adı boş bırakılamaz");
                return View();
            }

            var role = new RoleUpdateDTO { Name = roleName };

            var response = await _httpClient.PostAsJsonAsync("AdminRole/Create", role);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Role");
            }

            TempDataMessage(response.ReasonPhrase);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateRoleName(int? id, string roleName)
        {
            if (id == null) RedirectToAction(nameof(Index));

            if (string.IsNullOrWhiteSpace(roleName))
            {
                ViewBagMessage("Role adı boş bırakılamaz");
                return View();
            }

            var roleUpdateDTO = new RoleUpdateDTO { Name = roleName };

            var response = await _httpClient.PutAsJsonAsync($"AdminRole/{id}", roleUpdateDTO);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            TempDataMessage(response.ReasonPhrase);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeUserRole(int? userId, int roleId)
        {
            if (userId == null) RedirectToAction(nameof(Index));

            var roleUpdateDTO = new RoleUpdateDTO { Id = roleId };

            var response = await _httpClient.PutAsJsonAsync($"AdminRole/Users/{userId}", roleUpdateDTO);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            TempDataMessage(response.ReasonPhrase);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));

            var response = await _httpClient.DeleteAsync($"AdminRole/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index), "Role");

            TempDataMessage(response.ReasonPhrase);

            return RedirectToAction(nameof(Index));
        }
    }
}



