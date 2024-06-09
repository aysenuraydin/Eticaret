
namespace Eticaret.File.Data
{
    public class FileDto
    {
        public string Name { get; set; } = null!;
        public string ContentType { get; set; } = null!;
        public byte[] Data { get; set; } = null!;
        public int Size => Data.Length;
    }
}





