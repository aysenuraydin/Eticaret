using System.ComponentModel.DataAnnotations;
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class RoleUpdateDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
