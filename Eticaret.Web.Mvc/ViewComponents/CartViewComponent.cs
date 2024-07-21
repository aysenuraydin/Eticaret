
using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public CartViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                using (var response = await _httpClient.GetAsync("Cart"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var products = await response.Content.ReadFromJsonAsync<List<CartItemListDTO>>();

                        return View(products);
                    }
                    else
                    {
                        return View(new List<CartItemListDTO>());
                    }
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                Console.WriteLine($"Request error: {httpRequestException.Message}");
                return View(new List<ProductListDTO>());
            }

        }

    }
}

