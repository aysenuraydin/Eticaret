using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public CategoriesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (var response = await _httpClient.GetAsync("Categories"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return View();
                }
                List<CategoryListDTO> products = await response.Content.ReadFromJsonAsync<List<CategoryListDTO>>() ?? new();

                return View(products);
            }
        }

    }
}

