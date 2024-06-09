using System.ComponentModel.DataAnnotations;
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class RoleListWithUserDTO
    {
        [Required(ErrorMessage = "Kategori ID'si gereklidir.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı gereklidir.")]
        [MaxLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; } = null!;
        public List<UserRole> Users { get; set; } = new();
    }
    public class UserRole
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
    }
    public class RoleUpdateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
