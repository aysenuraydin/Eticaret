using Eticaret.Application.Repositories;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;
using Eticaret.Application.Abstract;

namespace Eticaret.Application.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(EticaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}
