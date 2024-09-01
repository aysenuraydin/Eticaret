using FluentValidation;

namespace Eticaret.Dto
{
    public class Images
    {
        public int Id { get; set; }
        public string? Url { get; set; }
    }
    public class ImagesValidator : AbstractValidator<Images>
    {
        public ImagesValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Görsel ID alanı gereklidir.");

            RuleFor(x => x.Url)
                .NotEmpty().WithMessage("Görsel URL'si alanı gereklidir.")
                .Must(BeAValidUrl).WithMessage("Geçersiz URL formatı.");
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _)
                    && (url.StartsWith("http://") || url.StartsWith("https://"));
        }
    }
}
