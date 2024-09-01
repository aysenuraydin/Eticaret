using Eticaret.Application.Repositories;
using Eticaret.Domain;

namespace Eticaret.Application.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order?> GetOrdersItemsAsync(string orderCode);
        Task<List<Order>?> GetAllOrdersItemsAsync(int userId);
    }
}