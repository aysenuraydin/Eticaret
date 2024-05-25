
using Eticaret.Application.Abstract;
using Eticaret.Domain;
using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

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
            return View(new AdminCategoryCreateDTO());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCategoryCreateDTO category)
        {
            try
            {
                var json = JsonSerializer.Serialize(category);

                var response = await _httpClient.PostAsync("AdminCategory", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var newcategory = await response.Content.ReadFromJsonAsync<Category>();

                    return RedirectToAction(nameof(Index), "Home");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();

                    ViewBag.Error = error;
                    return View(category);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Error");
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminCategory/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<AdminCategoryListDTO>() ?? new();
                return View(product);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AdminCategoryListDTO category)
        {
            try
            {
                var json = JsonSerializer.Serialize(category);

                var response = await _httpClient.PutAsync($"AdminCategory/{category.Id}", new StringContent(json, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var updateCategory = await response.Content.ReadFromJsonAsync<AdminCategoryListDTO>();
                    return RedirectToAction(nameof(Index), "Home");
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
            using (var response = await _httpClient.GetAsync($"AdminCategory/{id}"))
            {
                var product = await response.Content.ReadFromJsonAsync<AdminCategoryListDTO>() ?? new();
                return View(product);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdminCategoryListDTO category)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"AdminCategory/{id}");

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index), "Home");
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



