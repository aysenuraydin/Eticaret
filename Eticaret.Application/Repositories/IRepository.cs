using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

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


        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);

        DbSet<T> GetDb();

        //Task<T> FindAsync(int id);
        Task AddAsync(T entity);
        //Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        Task<int> SaveChangesAsync();



    }
}
