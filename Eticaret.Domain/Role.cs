using Eticaret.Domain.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class Role : IdentityRole<int>, IBaseEntity
    {
        [Display(Name = "Oluşturma Tarihi")]
        [Required(ErrorMessage = "Oluşturma tarihi alanı gereklidir.")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        #region Navigation Properties
        [Display(Name = "Kullanıcılar")]
        public List<User> Users { get; set; } = new();
        #endregion
    }
}

