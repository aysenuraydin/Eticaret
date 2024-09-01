using Eticaret.Application.Repositories;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;
using Eticaret.Application.Abstract;

namespace Eticaret.Application.Concrete
{
    public class ProductImageRepository : Repository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(EticaretDbContext dbContext) : base(dbContext)
        {
        }
    }
}