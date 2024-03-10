namespace Eticaret.Web.Mvc.Models
{
    public class ErrorViewModel  //a- kendiliIinden vardI bu sayfa
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}