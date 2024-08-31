using FluentValidation;

namespace Eticaret.Dto
{
    public class RegisterDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alanı gereklidir.")
                .Length(2, 50).WithMessage("Ad en fazla 50 karakter uzunluğunda olmalıdır ve en az 2 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alanı gereklidir.")
                .Length(2, 50).WithMessage("Soyad en fazla 50 karakter uzunluğunda olmalıdır ve en az 2 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta alanı gereklidir.")
                .EmailAddress().WithMessage("Geçersiz e-posta adresi.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı gereklidir.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter uzunluğunda olmalıdır.");
        }
    }

}
