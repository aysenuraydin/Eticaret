using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class SellerProductCreateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Details { get; set; } = null!;

        public List<UpdateImage> ImageList { get; set; } = new();

        public byte StockAmount { get; set; }

        public int CategoryId { get; set; }

        public int SellerId { get; set; }

        public bool Enabled { get; set; }
    }
    public class SellerProductCreateDTOValidator : AbstractValidator<SellerProductCreateDTO>
    {
        public SellerProductCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı alanı gereklidir.")
                .Length(2, 100).WithMessage("Ürün adı en az 2, en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Ürün ücreti 1'den büyük olmalıdır.");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Ürün açıklaması alanı gereklidir.")
                .Length(2, 100).WithMessage("Ürün açıklaması en az 2, en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.ImageList)
                .NotEmpty().WithMessage("Ürün resimleri listesi boş olamaz.");

            RuleForEach(x => x.ImageList)
                .SetValidator(new UpdateImageValidator())
                .WithMessage("Geçersiz resim URL'si veya ürün ID'si.");

            RuleFor(x => x.StockAmount)
            .Custom((value, context) =>
            {
                int starCount = value; // byte'dan int'e dönüştür
                if (starCount < 1 || starCount > 5)
                {
                    context.AddFailure("Yıldız sayısı 1 ile 255 arasında olmalıdır.");
                }
            });

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori alanı gereklidir.");

            RuleFor(x => x.SellerId)
                .GreaterThan(0).WithMessage("Satıcı ID'si geçerli olmalıdır.");
        }
    }
}
