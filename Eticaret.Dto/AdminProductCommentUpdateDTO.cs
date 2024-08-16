using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminProductCommentUpdateDTO
    {
        public int Id { get; set; }

        public bool IsConfirmed { get; set; }
    }
    public class AdminProductCommentUpdateDTOValidator : AbstractValidator<AdminProductCommentUpdateDTO>
    {
        public AdminProductCommentUpdateDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Yorum ID'si gereklidir.");
        }
    }
}
