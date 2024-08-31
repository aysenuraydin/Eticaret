
using Eticaret.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class ProductRatingViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        public ProductRatingViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            List<ProductCommentListDTO> comments = new List<ProductCommentListDTO>();
            int yuvarlanmisSayi = 0;

            var response = await _httpClient.GetAsync($"ProductComment/{id}");
            try
            {
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrWhiteSpace(responseContent))
                    {
                        comments = await response.Content.ReadFromJsonAsync<List<ProductCommentListDTO>>() ?? new List<ProductCommentListDTO>();

                        var commentRating = comments.Select(p => (decimal)p.StarCount).ToList();
                        if (commentRating.Count != 0)
                        {
                            double averageRating = (double)Math.Round(commentRating.Average());
                            yuvarlanmisSayi = (int)Math.Ceiling(averageRating);
                        }
                    }
                }
                else
                {
                    var errorMessage = $"Error: {response.StatusCode}, {response.ReasonPhrase}";
                    Console.WriteLine(errorMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return View(yuvarlanmisSayi);
        }
    }
}


