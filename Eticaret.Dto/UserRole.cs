using System.ComponentModel.DataAnnotations;
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class UserRole
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
    }
}
