
using Eticaret.Domain.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eticaret.Domain
{
    public class Seller : BaseEntity
    {
        public string? Name { get; set; }

    }
}