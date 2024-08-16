using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCategoryCreateDTO category)
        {
            if (!ModelState.IsValid) return View(category);

            var response = await _httpClient.PostAsJsonAsync("AdminCategory", category);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";

            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminCategory/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<AdminCategoryListDTO>() ?? new();

                if (response.IsSuccessStatusCode)
                {
                    var p = new AdminCategoryUpdateDTO()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Css = product.Css,
                        Color = product.Color
                    };

                    return View(p);
                }

                TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdminCategoryUpdateDTO category)
        {
            if (!ModelState.IsValid) return View(category);

            var response = await _httpClient.PutAsJsonAsync($"AdminCategory/{id}", category);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");

            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetAsync($"AdminCategory/{id}");

            if (response.IsSuccessStatusCode)
            {
                var product = await response.Content.ReadFromJsonAsync<AdminCategoryListDTO>() ?? new();

                return View(product);
            }

            TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdminCategoryListDTO category)
        {
            var response = await _httpClient.DeleteAsync($"AdminCategory/{id}");

            if (response.IsSuccessStatusCode) RedirectToAction("Index", "Home");

            TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";

            return RedirectToAction("Index", "Home");
        }
    }
}



