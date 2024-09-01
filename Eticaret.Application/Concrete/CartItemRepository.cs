using Eticaret.Application.Repositories;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;
using Eticaret.Application.Abstract;

namespace Eticaret.Application.Concrete
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(EticaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}