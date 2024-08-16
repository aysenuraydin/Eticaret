using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Eticaret.Dto
{
    public class CartItemUpdateDTO
    {
        public int Id { get; set; }
        public byte Quantity { get; set; }
    }

}