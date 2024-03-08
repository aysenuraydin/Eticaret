using Eticaret.Application.Dtos;
using Eticaret.Domain;

namespace Eticaret.Application.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetAllBySearch(SearchDto parameters);
        Product? GetById(int id);
    }
}