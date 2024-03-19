
using Eticaret.Application.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ticaret.Web.Mvc.ViewComponents
{
    public class ProductRatingViewComponent : ViewComponent
    {
        private readonly IProductCommentRepository _comentService;

        public ProductRatingViewComponent(IProductCommentRepository comentService)
        {
            _comentService = comentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            int yuvarlanmisSayi;
            var c = await _comentService.GetAllAsync();
            var commentRating = c.Where(p => p.ProductId == id && p.IsConfirmed).Select(p => (decimal)p.StarCount).ToList();
            if (commentRating.Count == 0)
            {
                yuvarlanmisSayi = 0;
            }
            else
            {
                double averageRating = (double)Math.Round(commentRating.Average());
                yuvarlanmisSayi = (int)Math.Ceiling(averageRating);
            }
            return View(yuvarlanmisSayi);
        }
    }
}

