using Eticaret.Application.Abstract;
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public CommentViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5177/api/");
        }

        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            using (var response = await _httpClient.GetAsync($"ProductComment/{id}"))
            {
                List<ProductCommentListDTO> comments = await response.Content.ReadFromJsonAsync<List<ProductCommentListDTO>>() ?? new();

                return View(comments);
            }
        }

    }
}

