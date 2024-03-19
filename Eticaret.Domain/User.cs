
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Eticaret.Domain
{
    public class User : BaseEntity
    {

        public string? Email { get; set; }

        [MaxLength(50), MinLength(2)]
        public string? FirstName { get; set; }
        [MaxLength(50), MinLength(2)]
        public string? LastName { get; set; }
        [MinLength(1)]
        public string? Password { get; set; }
        public bool Enabled { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //[ForeignKey("Role")]
        public int RoleId { get; set; }
        public int? CartId { get; set; }

        #region Navigation Properties
        public Role? RoleFk { get; set; }
        public Cart? CartFk { get; set; }
        public List<ProductComment> ProductComments { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        #endregion


    }
}