
using Eticaret.Domain;

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
        public int CartItemCount { get; set; }
        public int ProductCommentCount { get; set; }
        public int OrderCount { get; set; }
    }
    public class AdminUserUpdateDTO
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
    }
}




