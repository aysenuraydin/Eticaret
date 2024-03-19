using Eticaret.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Role : BaseEntity
    {
        [Display(Name = "Rol Adı")]
        [Required(ErrorMessage = "Rol adı alanı gereklidir.")]
        [MinLength(2, ErrorMessage = "Rol adı en az 2 karakterden oluşmalıdır.")]
        [MaxLength(50, ErrorMessage = "Rol adı en fazla 50 karakter uzunluğunda olmalıdır.")]
        public string? Name { get; set; }

        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        #region Navigation Properties
        [Display(Name = "Kullanıcılar")]
        public List<User> Users { get; set; } = new();
        #endregion
    }
}

