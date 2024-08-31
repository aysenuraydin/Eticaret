using FluentValidation;

namespace Eticaret.Dto
{
    public class UpdateImage
    {
        public string Url { get; set; } = null!;

        public int ProductId { get; set; }

        public int SellerId { get; set; }
    }
    public class UpdateImageValidator : AbstractValidator<UpdateImage>
    {
        public UpdateImageValidator()
        {
            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Resim URL alanı gereklidir.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün alanı gereklidir.")
                .GreaterThan(0).WithMessage("Ürün ID'si geçerli bir değer olmalıdır.");

            RuleFor(x => x.SellerId)
                .NotEmpty().WithMessage("Satıcı alanı gereklidir.")
                .GreaterThan(0).WithMessage("Satıcı ID'si geçerli bir değer olmalıdır.");
        }
    }
}
