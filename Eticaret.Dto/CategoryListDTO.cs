using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class CategoryListDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
    public class CategoryListDTOValidator : AbstractValidator<CategoryListDTO>
    {
        public CategoryListDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kategori ID'si gereklidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Kategori adı gereklidir.")
                .MaximumLength(100).WithMessage("Kategori adı en fazla 100 karakter uzunluğunda olmalıdır.");
        }
    }
}
