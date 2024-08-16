using System.ComponentModel.DataAnnotations;
using Eticaret.Domain;
using FluentValidation;

namespace Eticaret.Dto
{
    public class OrderDTO
    {
        public string? Address { get; set; } = null!;
    }
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres alanı gereklidir.")
                .MaximumLength(250).WithMessage("Adres en fazla 250 karakter uzunluğunda olmalıdır.");
        }
    }
}
