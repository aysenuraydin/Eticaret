using System.ComponentModel.DataAnnotations;

namespace Eticaret.WebApi.Models.ConfigModels
{
    public class SerilogConfigModel
    {
        [Required]
        public List<string> Using { get; set; } = new();

        [Required]
        public MinimumLevelConfigModel MinimumLevel { get; set; } = new();

        [Required]
        public List<WriteToConfigModel> WriteTo { get; set; } = new();

        [Required]
        public List<string> Enrich { get; set; } = new();
    }

    public class MinimumLevelConfigModel
    {
        [Required]
        public string Default { get; set; } = default!;

        [Required]
        public Dictionary<string, string> Override { get; set; } = new();
    }

    public class WriteToConfigModel
    {
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public ArgsConfigModel Args { get; set; } = new();
    }

    public class ArgsConfigModel
    {
        [Required]
        public string PathFormat { get; set; } = default!;

        [Required]
        public string OutputTemplate { get; set; } = default!;

        [Required]
        public string RollingInterval { get; set; } = default!;
    }
}