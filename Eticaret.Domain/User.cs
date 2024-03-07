
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class User : BaseEntity
    {

        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }

        #region Navigation Properties
        public Role? RoleFk { get; set; }
        #endregion


    }
}