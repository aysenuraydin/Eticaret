using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public CategoriesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
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

