using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class ProductCommentListDTO
    {
        public string? Text { get; set; }

        public byte StarCount { get; set; }

        public string? UserName { get; set; }
    }
    public class ProductCommentListDTOValidator : AbstractValidator<ProductCommentListDTO>
    {
        public ProductCommentListDTOValidator()
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
            RuleFor(x => x.UserName)
                .MaximumLength(100).WithMessage("Kullanıcı adı en fazla 100 karakter uzunluğunda olmalıdır.");
        }
    }
}
