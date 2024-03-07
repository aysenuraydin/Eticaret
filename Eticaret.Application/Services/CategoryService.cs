using Microsoft.EntityFrameworkCore;
using Eticaret.Application.Services.Interfaces;
using Eticaret.Domain;
using Eticaret.Persistence.Ef;

namespace Eticaret.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EticaretDbContext _db;

        public CategoryService(EticaretDbContext db)
        {
            _db = db;
        }

        public Task<List<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Category? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
