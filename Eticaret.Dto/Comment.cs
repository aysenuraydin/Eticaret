using FluentValidation;

namespace Eticaret.Dto
{

    public class Comment
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        public byte StarCount { get; set; }

        public bool IsConfirmed { get; set; } = false;

        public string CreatedAt { get; set; } = string.Empty;

        public string? UserName { get; set; }
    }
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Yorum ID alanı gereklidir.");

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

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("Oluşturma tarihi alanı gereklidir.");

            RuleFor(x => x.UserName)
                .MaximumLength(100).WithMessage("Kullanıcı adı en fazla 100 karakter uzunluğunda olmalıdır.");
        }
    }
}
