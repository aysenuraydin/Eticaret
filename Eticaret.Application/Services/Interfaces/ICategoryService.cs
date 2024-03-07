using Eticaret.Domain;

namespace Eticaret.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Category? GetById(int id);
    }
}