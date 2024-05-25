
using Eticaret.Domain;

namespace Eticaret.Dto
{
    public class AdminProductCommentListDTO
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public byte StarCount { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public string? CreatedAt { get; set; }
        public string? UserName { get; set; }
        public string? ProductName { get; set; }
    }
    public class AdminProductCommentUpdateDTO
    {
        public int Id { get; set; }
        public bool IsConfirmed { get; set; }
    }
}



