using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public CommentViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            using (var response = await _httpClient.GetAsync($"ProductComment/{id}"))
            {
                if (!response.IsSuccessStatusCode)
                {
                    return View();
                }
                List<ProductCommentListDTO> comments = await response.Content.ReadFromJsonAsync<List<ProductCommentListDTO>>() ?? new();

                return View(comments);
            }
        }

    }
}

