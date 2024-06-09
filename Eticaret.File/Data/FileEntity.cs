

namespace Eticaret.File.Data
{
    public class FileEntity
    {
        public int? Id { get; set; } = null!;
        public string OriginalName { get; set; } = null!;
        public string LocalName { get; set; } = Guid.NewGuid().ToString();
        public string? ContentType { get; set; }
        public string? Extension { get; set; }
        public long Size { get; set; }
        public string? FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
