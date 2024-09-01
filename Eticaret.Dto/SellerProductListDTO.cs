using FluentValidation;

namespace Eticaret.Dto
{
    public class SellerProductListDTO : AdminProductListDTO
    {
        public int CategoryId { get; set; }
    }
    public class SellerProductListDTOValidator : AbstractValidator<SellerProductListDTO>
    {
        public SellerProductListDTOValidator()
        {
            Include(new AdminProductListDTOValidator());

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Kategori alanı gereklidir.");
        }
    }
}




