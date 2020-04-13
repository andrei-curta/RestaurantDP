using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public class BaseRepository<T> : IRepository<T> 
        where T : class
    {

        private readonly MyContext _dbContext;

        public BaseRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public T GetByID(object id)
        {
           return _dbContext.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T item)
        {

            _dbContext.Set<T>().Update(item);
            _dbContext.Entry(item).State = EntityState.Modified;

            _dbContext.SaveChanges();
        }
    }
}
