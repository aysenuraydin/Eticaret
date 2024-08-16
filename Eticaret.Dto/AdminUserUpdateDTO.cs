using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminUserUpdateDTO
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
    }
    public class AdminUserUpdateDTOValidator : AbstractValidator<AdminUserUpdateDTO>
    {
        public AdminUserUpdateDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kullanıcı ID'si gereklidir.");
        }
    }
}
