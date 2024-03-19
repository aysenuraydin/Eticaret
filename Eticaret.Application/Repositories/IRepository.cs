using System.Linq.Expressions;

namespace Eticaret.Application.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> expression);
        T Get(Expression<Func<T, bool>> expression);
        T Find(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int SaveChanges();

        IQueryable<T> GetAllInclude(string table);
        IQueryable<T> GetAllInclude(Expression<Func<T, bool>> expression);

    }
}
