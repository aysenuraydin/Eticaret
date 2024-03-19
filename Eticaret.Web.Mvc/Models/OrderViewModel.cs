using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Eticaret.Domain;

namespace Eticaret.Web.Mvc.Models
{
    public class OrderViewModel
    {
        public List<CartItem>? CartItems { get; set; } = new();

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Adres alanı gereklidir.")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Adres en az 2, en fazla 250 karakter uzunluğunda olmalıdır.")]
        public string? Address { get; set; }
    }
}