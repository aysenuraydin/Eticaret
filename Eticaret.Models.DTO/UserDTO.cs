
using AutoMapper;
using Eticaret.Domain;

namespace Eticaret.Models.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RoleId { get; set; }

    }
}


