using System.ComponentModel.DataAnnotations;

namespace Eticaret.Web.Mvc.Models.ConfigModels
{ //!
    public abstract class ApiAccessConfigModel
    {
        [Required]
        public string Name { get; set; } = default!;
        public string BaseUrl { get; set; } = default!;

        [Required, Range(1, 300)]
        public int TimeoutSeconds { get; set; }
        public bool UseJwt { get; set; }
    }

    public sealed class FileApiAccessConfigModel : ApiAccessConfigModel
    {
    }

    public sealed class DataApiAccessConfigModel : ApiAccessConfigModel
    {
    }
}
