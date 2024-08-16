using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminProductCommentListDTO
    {
        public int Id { get; set; }

        public string? Text { get; set; }
        public byte StarCount { get; set; }

        public bool IsConfirmed { get; set; } = false;
        public string? CreatedAt { get; set; }

        public string? UserName { get; set; }

        public string? ProductName { get; set; }
    }
    public class AdminProductCommentListDTOValidator : AbstractValidator<AdminProductCommentListDTO>
    {
        public AdminProductCommentListDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Yorum ID'si gereklidir.");

            RuleFor(x => x.StarCount)
                .Custom((value, context) =>
                {
                    int starCount = value;
                    if (starCount < 1 || starCount > 5)
                    {
                        context.AddFailure("Yıldız sayısı 1 ile 5 arasında olmalıdır.");
                    }
                });

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("Oluşturma tarihi gereklidir.");
        }
    }
}
