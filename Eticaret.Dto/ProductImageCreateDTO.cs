using FluentValidation;

namespace Eticaret.Dto
{
    public class ProductImageCreateDTO
    {
        public string? Url { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
    }

    public class ProductImageCreateDTOValidator : AbstractValidator<ProductImageCreateDTO>
    {
        public ProductImageCreateDTOValidator()
        {
            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Görsel URL'si alanı gereklidir.")
                .Must(BeAValidUrl).WithMessage("Geçersiz URL formatı.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Ürün ID alanı gereklidir.");

            RuleFor(x => x.SellerId)
                .GreaterThan(0).WithMessage("Satıcı ID alanı gereklidir.");
        }

        private bool BeAValidUrl(string? url)
        {
            return !string.IsNullOrEmpty(url) && Uri.TryCreate(url, UriKind.Absolute, out var result) &&
                (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }
    }

}
