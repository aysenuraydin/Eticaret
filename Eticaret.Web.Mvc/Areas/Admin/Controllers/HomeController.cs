using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                using (var response = await _httpClient.GetAsync("AdminCategory"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var products = await response.Content.ReadFromJsonAsync<List<AdminCategoryListDTO>>() ?? [];

                        return View(products);
                    }

                    ViewBag.ErrorMessage = $"Error In: {response.ReasonPhrase}";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Error catch: {ex.Message}";
            }

            return View(new List<AdminCategoryListDTO>());
        }
    }
}

