using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class ProductDetailDTO
    {
        [Display(Name = "Ürün ID")]
        [Required(ErrorMessage = "Ürün ID alanı gereklidir.")]
        public int Id { get; set; }

        [Display(Name = "Ürün Adı")]
        [MaxLength(100, ErrorMessage = "Ürün adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Ürün adı en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün adı alanı gereklidir.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Ürün Ücreti")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Ürün ücreti alanı gereklidir.")]
        [Range(1, 1000000, ErrorMessage = "Ürün ücreti 1 ile 1000000 arasında olmalıdır.")]
        public decimal Price { get; set; }

        [Display(Name = "Ürün Açıklaması")]
        [MaxLength(500, ErrorMessage = "Ürün açıklaması en fazla 500 karakter uzunluğunda olmalıdır.")]
        [MinLength(2, ErrorMessage = "Ürün açıklaması en az 2 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Ürün açıklaması alanı gereklidir.")]
        public string Details { get; set; } = null!;

        [Display(Name = "Stok Adedi")]
        [Required(ErrorMessage = "Stok adedi alanı gereklidir.")]
        [Range(1, 255, ErrorMessage = "Ürün adedi 1 ile 255 arasında olmalıdır.")]
        public byte StockAmount { get; set; }

        [Display(Name = "Kategori ID")]
        [Required(ErrorMessage = "Kategori ID alanı gereklidir.")]
        public int CategoryId { get; set; }

        [Display(Name = "Kategori Adı")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Kategori adı alanı gereklidir.")]
        public string CategoryName { get; set; } = null!;

        [Display(Name = "Satıcı Adı")]
        [MaxLength(100, ErrorMessage = "Satıcı adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        [Required(ErrorMessage = "Satıcı adı alanı gereklidir.")]
        public string SellerName { get; set; } = null!;

        [Display(Name = "Ürün Yorumları")]
        public List<Comment> ProductComments { get; set; } = new();

        [Display(Name = "Ürün Görselleri")]
        public List<Images> ProductImagesUrl { get; set; } = new();
    }
    public class ProductDetailDTOValidator : AbstractValidator<ProductDetailDTO>
    {
        public ProductDetailDTOValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Ürün ID alanı gereklidir.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı alanı gereklidir.")
                .Length(2, 100).WithMessage("Ürün adı en az 2 ve en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Ürün ücreti alanı gereklidir.")
                .InclusiveBetween(1, 1000000).WithMessage("Ürün ücreti 1 ile 1,000,000 arasında olmalıdır.");

            RuleFor(x => x.Details)
            .NotEmpty().WithMessage("Ürün açıklaması alanı gereklidir.")
            .Length(2, 500).WithMessage("Ürün açıklaması en az 2 ve en fazla 500 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.StockAmount)
            .Custom((value, context) =>
            {
                int starCount = value; // byte'dan int'e dönüştür
                if (starCount < 1 || starCount > 5)
                {
                    context.AddFailure("Yıldız sayısı 1 ile 255 arasında olmalıdır.");
                }
            });

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Kategori ID alanı gereklidir.");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Kategori adı alanı gereklidir.")
                .Length(1, 100).WithMessage("Kategori adı en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.SellerName)
                .NotEmpty().WithMessage("Satıcı adı alanı gereklidir.")
                .Length(1, 100).WithMessage("Satıcı adı en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.ProductComments)
                .NotNull().WithMessage("Ürün yorumları boş olamaz.");

            RuleFor(x => x.ProductImagesUrl)
                .NotNull().WithMessage("Ürün görselleri boş olamaz.");
        }
    }
}
