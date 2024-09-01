using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    public class HomeController : AppController
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
        }
        public async Task<IActionResult> Index()
        {
            if (TempData["ErrorMessage"] != null) ViewBagMessage(TempData["ErrorMessage"].ToString());

            using (var response = await _httpClient.GetAsync("AdminCategory"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var products = await response.Content.ReadFromJsonAsync<List<AdminCategoryListDTO>>() ?? new List<AdminCategoryListDTO>();
                    return View(products);
                }
                ViewBagMessage(response.ReasonPhrase);
            }
            return View();
        }
    }
}

