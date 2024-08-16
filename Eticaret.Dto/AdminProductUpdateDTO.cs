using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminProductUpdateDTO
    {
        public int Id { get; set; }

        public bool IsConfirmed { get; set; }
    }
    public class AdminProductUpdateDTOValidator : AbstractValidator<AdminProductUpdateDTO>
    {
        public AdminProductUpdateDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Ürün ID'si gereklidir.");
        }
    }
}
