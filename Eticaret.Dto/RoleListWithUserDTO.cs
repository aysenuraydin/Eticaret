using FluentValidation;

namespace Eticaret.Dto
{
    public class RoleListWithUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<UserRole> Users { get; set; } = new();
    }
    public class RoleListWithUserDTOValidator : AbstractValidator<RoleListWithUserDTO>
    {
        public RoleListWithUserDTOValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Kategori ID'si geçerli olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı gereklidir.")
                .Length(1, 100).WithMessage("Kategori adı en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Users)
                .NotNull().WithMessage("Kullanıcı listesi boş olamaz.");
        }
    }
}
