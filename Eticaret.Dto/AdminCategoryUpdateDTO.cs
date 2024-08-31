using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminCategoryUpdateDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Color { get; set; }
        public string? Css { get; set; }
    }
    public class AdminCategoryUpdateDTOValidator : AbstractValidator<AdminCategoryUpdateDTO>
    {
        public AdminCategoryUpdateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı gereklidir.");
        }
    }
}
