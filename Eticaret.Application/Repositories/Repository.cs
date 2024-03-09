using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Eticaret.Domain.Abstract;
using Eticaret.Persistence.Ef;

namespace Eticaret.Application.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IBaseEntity, new()
    {
        internal readonly EticaretDbContext _databaseContext;
        DbSet<T> _dbSet;
        public Repository(EticaretDbContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<T>();
        }


        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression)!;
        }

        public T Find(int id)
        {
            return _dbSet.Find(id)!;
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return SaveChanges();
        }

        public int Update(T entity)
        {
            _databaseContext.Update(entity);
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return SaveChanges();
        }

        public int SaveChanges()
        {
            return _databaseContext.SaveChanges();
        }

        public IQueryable<T> GetAllInclude(string table)
        {
            return _dbSet.Include(table);
        }

        public IQueryable<T> GetAllInclude(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Include(expression);
        }

#nullable disable
#nullable restore



    }
}
