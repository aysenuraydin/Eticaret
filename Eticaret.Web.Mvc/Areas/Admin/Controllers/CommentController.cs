using Eticaret.Dto;
using Eticaret.Web.Mvc.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    public class CommentController : AppController
    {
        private readonly HttpClient _httpClient;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(ApplicationSettings.DATA_API_CLIENT);
        }

        public async Task<IActionResult> List()
        {
            if (TempData["ErrorMessage"] != null) ViewBagMessage(TempData["ErrorMessage"].ToString());

            var response = await _httpClient.GetAsync("AdminProductComment");

            if (response.IsSuccessStatusCode)
            {
                var comments = await response.Content.ReadFromJsonAsync<List<AdminProductCommentListDTO>>() ?? new();

                return View(comments);
            }

            ViewBagMessage(response.ReasonPhrase);

            return View();
        }

        public async Task<IActionResult> Approve(int id)
        {
            var response = await _httpClient.GetAsync($"AdminProductComment/{id}");

            if (response.IsSuccessStatusCode)
            {
                AdminProductCommentListDTO comment = await response.Content.ReadFromJsonAsync<AdminProductCommentListDTO>() ?? new();

                return View(comment);
            }

            ViewBagMessage(response.ReasonPhrase);

            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(AdminProductCommentListDTO comment)
        {
            AdminProductCommentUpdateDTO c = new()
            {
                Id = comment.Id,
                IsConfirmed = comment.IsConfirmed

            };

            var response = await _httpClient.PutAsJsonAsync($"AdminProductComment/{comment.Id}", c);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(List));
            }

            ViewBagMessage(response.ReasonPhrase);
            ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");

            return View(comment);
        }

        public async Task<IActionResult> Delete(int id)
        {
            using (var response = await _httpClient.GetAsync($"AdminProductComment/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    AdminProductCommentListDTO product = await response.Content.ReadFromJsonAsync<AdminProductCommentListDTO>() ?? new();

                    return View(product);
                }

                ViewBagMessage(response.ReasonPhrase);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdminProductCommentListDTO? comment)
        {
            var response = await _httpClient.DeleteAsync($"AdminProductComment/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(List));

            TempDataMessage(response.ReasonPhrase);
            return RedirectToAction(nameof(List));
        }
    }
}