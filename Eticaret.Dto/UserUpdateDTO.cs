using FluentValidation;

namespace Eticaret.Dto
{
    public class UserUpdateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class UserUpdateDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alanı gereklidir.")
                .MinimumLength(2).WithMessage("Ad en az 2 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("Ad en fazla 50 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyadı alanı gereklidir.")
                .MinimumLength(2).WithMessage("Soyadı en az 2 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("Soyadı en fazla 50 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Mail adresi alanı gereklidir.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı gereklidir.")
                .MinimumLength(6).WithMessage("Şifre en az 1 karakterden oluşmalıdır.")
                .When(x => !string.IsNullOrWhiteSpace(x.Password));
        }
    }
}
