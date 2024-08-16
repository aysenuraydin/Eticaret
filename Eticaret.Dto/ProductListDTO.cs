using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class ProductListDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
    public class ProductListDTOValidator : AbstractValidator<ProductListDTO>
    {
        public ProductListDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Ürün ID alanı gereklidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı alanı gereklidir.")
                .Length(2, 100).WithMessage("Ürün adı en fazla 100 karakter uzunluğunda olmalıdır ve en az 2 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Ürün ücreti alanı gereklidir.")
                .InclusiveBetween(1, 1000000).WithMessage("Ürün ücreti 1 ile 1,000,000 arasında olmalıdır.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Ürün görsel URL'si alanı gereklidir.");
        }
    }

}
