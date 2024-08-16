using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class ProductImageListDTO
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? CreatedAt { get; set; }
        public int ProductId { get; set; }
        public int SellerId { get; set; }
    }

    public class ProductImageListDTOValidator : AbstractValidator<ProductImageListDTO>
    {
        public ProductImageListDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Görsel ID alanı gereklidir.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Görsel URL'si alanı gereklidir.")
                .Must(BeAValidUrl).WithMessage("Geçersiz URL formatı.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("Oluşturma tarihi alanı gereklidir.");

            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Ürün ID alanı gereklidir.");

            RuleFor(x => x.SellerId)
                .NotEmpty().WithMessage("Satıcı ID alanı gereklidir.");
        }

        private bool BeAValidUrl(string? url)
        {
            return !string.IsNullOrEmpty(url) && Uri.TryCreate(url, UriKind.Absolute, out var result) &&
                (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
        }
    }

}
