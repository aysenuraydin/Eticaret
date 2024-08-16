using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminProductListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public List<string?> ImageUrlList { get; set; } = new List<string?>();

        public string Details { get; set; } = null!;

        public byte StockAmount { get; set; }

        public string? CategoryName { get; set; }
        public string? CategoryColor { get; set; }

        public string? CreatedAt { get; set; }

        public bool Enabled { get; set; }
        public bool IsConfirmed { get; set; }

        public string? SellerName { get; set; }

        public int CommentCount { get; set; }

        public int OrderCount { get; set; }

        public int CartCount { get; set; }
    }
    public class AdminProductListDTOValidator : AbstractValidator<AdminProductListDTO>
    {
        public AdminProductListDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Ürün ID'si gereklidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı alanı gereklidir.")
                .Length(1, 100).WithMessage("Ürün adı en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Geçersiz ürün fiyatı.");

            RuleFor(x => x.ImageUrlList)
                .NotNull().WithMessage("Ürün resim URL listesi alanı gereklidir.")
                .Must(list => list != null && list.All(url => !string.IsNullOrWhiteSpace(url)))
                .WithMessage("Geçersiz resim URL'leri.");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Ürün detayları alanı gereklidir.");

            RuleFor(x => x.StockAmount)
            .Custom((value, context) =>
            {
                int starCount = value; // byte'dan int'e dönüştür
                if (starCount < 1 || starCount > 255)
                {
                    context.AddFailure("Geçersiz stok miktarı.");
                }
            });

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("Oluşturma tarihi alanı gereklidir.");

            RuleFor(x => x.SellerName)
                .NotEmpty().WithMessage("Satıcı adı alanı gereklidir.");

            RuleFor(x => x.CommentCount)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Geçersiz yorum sayısı.");

            RuleFor(x => x.OrderCount)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Geçersiz sipariş sayısı.");

            RuleFor(x => x.CartCount)
            .InclusiveBetween(0, int.MaxValue).WithMessage("Geçersiz sepet sayısı.");

        }
    }
}
