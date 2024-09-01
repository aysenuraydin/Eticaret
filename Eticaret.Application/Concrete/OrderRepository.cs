using Microsoft.EntityFrameworkCore;
using Eticaret.Application.Repositories;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;
using Eticaret.Application.Abstract;

namespace Eticaret.Application.Concrete
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly EticaretDbContext _context;
        public OrderRepository(EticaretDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
        public async Task<Order?> GetOrdersItemsAsync(string orderCode)
        {
            return await _context.Orders
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.ProductFk)
                    .ThenInclude(p => p.ProductImages)
                    .FirstOrDefaultAsync(o => o.OrderCode == orderCode);
        }
        public async Task<List<Order>?> GetAllOrdersItemsAsync(int userId)
        {
            return await _context.Orders
                    .Where(o => o.UserId == userId)
                    .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.ProductFk)
                    .ThenInclude(p => p.ProductImages)
                    .ToListAsync();
        }
    }
}

#nullable disable

#nullable restore