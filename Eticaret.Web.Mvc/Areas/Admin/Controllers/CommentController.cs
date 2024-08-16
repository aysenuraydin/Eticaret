using Eticaret.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eticaret.Web.Mvc.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "admin")]
    public class CommentController : Controller
    {
        private readonly HttpClient _httpClient;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("api");
        }

        public async Task<IActionResult> List()
        {
            if (TempData["ErrorMessage"] != null) ViewBag.ErrorMessage = TempData["ErrorMessage"];

            var response = await _httpClient.GetAsync("AdminProductComment");

            if (response.IsSuccessStatusCode)
            {
                var comments = await response.Content.ReadFromJsonAsync<List<AdminProductCommentListDTO>>() ?? new();

                return View(comments);
            }

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";

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

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";

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

            ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
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

                ViewBag.ErrorMessage = $"Error: {response.ReasonPhrase}";
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AdminProductCommentListDTO? comment)
        {
            var response = await _httpClient.DeleteAsync($"AdminProductComment/{id}");

            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(List));

            TempData["ErrorMessage"] = $"Error: {response.ReasonPhrase}";
            return RedirectToAction(nameof(List));
        }
    }
}