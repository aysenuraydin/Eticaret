namespace Eticaret.Web.Mvc.Areas.Admin.Models
{
    public class ErrorViewModel  //a- kendiliIinden vardI bu sayfa
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}