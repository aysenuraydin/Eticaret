using FluentValidation;

namespace Eticaret.Dto
{
    public class ProductCommentCreateDTO
    {
        public string? Text { get; set; }

        public byte StarCount { get; set; }

        public int? UserId { get; set; }

        public int ProductId { get; set; }
    }
    public class ProductCommentCreateDTOValidator : AbstractValidator<ProductCommentCreateDTO>
    {
        public ProductCommentCreateDTOValidator()
        {
            RuleFor(x => x.Text)
                .MaximumLength(500).WithMessage("Yorum metni en fazla 500 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.StarCount)
                        .Custom((value, context) =>
                        {
                            int starCount = value; // byte'dan int'e dönüştür
                            if (starCount < 1 || starCount > 5)
                            {
                                context.AddFailure("Yıldız sayısı 1 ile 5 arasında olmalıdır.");
                            }
                        });

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün ID alanı gereklidir.");

            // UserId optional olduğu için herhangi bir kısıtlama getirilmedi
            RuleFor(x => x.UserId)
                .NotNull().When(x => x.UserId.HasValue).WithMessage("Kullanıcı ID geçerli olmalıdır.");
        }
    }
}
