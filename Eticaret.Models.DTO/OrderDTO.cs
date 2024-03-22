
namespace Eticaret.Models.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string? OrderCode { get; set; }
        public string? Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

    }
}



