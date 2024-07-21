using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class WomenBannerViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public WomenBannerViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (var response = await _httpClient.GetAsync("Home?start=0&take=5"))//paging!
            {
                if (!response.IsSuccessStatusCode)
                {
                    return View(new List<ProductListDTO>());
                }
                List<ProductListDTO> products = await response.Content.ReadFromJsonAsync<List<ProductListDTO>>() ?? new();
                return View(products.Take(6).ToList());
            }
        }

    }
}

