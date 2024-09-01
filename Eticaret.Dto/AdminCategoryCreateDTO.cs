using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminCategoryCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string? Color { get; set; }
        public string? Css { get; set; }
    }
    public class AdminCategoryCreateDTOValidator : AbstractValidator<AdminCategoryCreateDTO>
    {
        public AdminCategoryCreateDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı gereklidir.");
        }
    }
}
