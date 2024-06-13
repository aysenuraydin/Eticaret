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
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
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

            try
            {
                var response = await _httpClient.PostAsJsonAsync("AdminCategory", category);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
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

                    ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AdminCategoryUpdateDTO category)
        {
            if (!ModelState.IsValid) return View(category);

            try
            {
                var response = await _httpClient.PutAsJsonAsync($"AdminCategory/{id}", category);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
                ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error:{ex.Message}";
                ModelState.AddModelError("", $"Hata Oluştu: {ex.Message}");

            }

            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"AdminCategory/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadFromJsonAsync<AdminCategoryListDTO>() ?? new();

                    return View(product);
                }

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdminCategoryListDTO category)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminCategory/{id}");

                if (response.IsSuccessStatusCode) RedirectToAction("Index", "Home");

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error: {ex.Message}";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}



