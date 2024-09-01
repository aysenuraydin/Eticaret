using FluentValidation;

namespace Eticaret.Dto
{

    public class SellerProductCreateOrUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Details { get; set; } = null!;
        public List<string> ImageList { get; set; } = new();

        public byte StockAmount { get; set; }

        public int CategoryId { get; set; }

        public int SellerId { get; set; }

        public bool Enabled { get; set; }
    }

    public class SellerProductCreateOrUpdateDTOValidator : AbstractValidator<SellerProductCreateOrUpdateDTO>
    {
        public SellerProductCreateOrUpdateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı alanı gereklidir.")
                .Length(2, 100).WithMessage("Ürün adı en az 2, en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Ürün ücreti alanı gereklidir.")
                .GreaterThan(0).WithMessage("Ürün ücreti 0'dan büyük olmalıdır.")
                .LessThanOrEqualTo(1000000).WithMessage("Ürün ücreti 1.000.000'dan büyük olmamalıdır.");

            RuleFor(x => x.Details)
                .NotEmpty().WithMessage("Ürün açıklaması alanı gereklidir.")
                .Length(2, 100).WithMessage("Ürün açıklaması en az 2, en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.ImageList)
                .NotNull().WithMessage("Ürün resimleri alanı gereklidir.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori alanı gereklidir.");

            RuleFor(x => x.SellerId)
                .NotEmpty().WithMessage("Satıcı alanı gereklidir.");

            RuleFor(x => x.StockAmount)
            .Custom((value, context) =>
            {
                int starCount = value; // byte'dan int'e dönüştür
                if (starCount < 1 || starCount > 255)
                {
                    context.AddFailure("Geçersiz stok miktarı.");
                }
            });
        }
    }
}
