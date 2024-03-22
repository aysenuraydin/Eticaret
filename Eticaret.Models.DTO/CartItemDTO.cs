using AutoMapper;
using Eticaret.Domain;
namespace Eticaret.Models.DTO
{
    public class CartItemDTO
    {
        public int Id { get; set; }
        public byte Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

    }
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CartItem, CartItemDTO>()
                .ReverseMap();
        }
    }
}