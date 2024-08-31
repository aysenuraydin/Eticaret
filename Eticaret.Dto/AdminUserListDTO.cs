using FluentValidation;

namespace Eticaret.Dto
{
    public class AdminUserListDTO
    {
        public int Id { get; set; }

        public string? Email { get; set; }

        public string? FullName { get; set; }

        public bool Enabled { get; set; } = false;

        public string? CreatedAt { get; set; }

        public string? RoleName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int CartItemCount { get; set; }

        public int ProductCommentCount { get; set; }

        public int OrderCount { get; set; }
    }
    public class AdminUserListDTOValidator : AbstractValidator<AdminUserListDTO>
    {
        public AdminUserListDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Kullanıcı ID'si gereklidir.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Geçersiz e-posta adresi formatı.");

            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Tam ad alanı gereklidir.")
                .MaximumLength(100).WithMessage("Tam ad en fazla 100 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.CreatedAt)
                .NotEmpty().WithMessage("Oluşturma tarihi alanı gereklidir.");

            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Rol adı alanı gereklidir.");

            RuleFor(x => x.CartItemCount)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Sepet öğe sayısı negatif olamaz.");

            RuleFor(x => x.ProductCommentCount)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Ürün yorumu sayısı negatif olamaz.");

            RuleFor(x => x.OrderCount)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Sipariş sayısı negatif olamaz.");
        }
    }

}

