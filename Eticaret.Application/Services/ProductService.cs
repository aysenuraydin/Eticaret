using Microsoft.EntityFrameworkCore;
using Eticaret.Application.Dtos;
using Eticaret.Application.Services.Interfaces;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;

namespace Eticaret.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly EticaretDbContext _db;

        public ProductService(EticaretDbContext db)
        {
            _db = db;
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllBySearch(SearchDto parameters)
        {
            throw new NotImplementedException();
        }

        public Product? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
