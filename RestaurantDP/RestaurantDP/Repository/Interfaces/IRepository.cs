using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
     public interface IRepository<T>
    {
        T Insert(T entity);

        void Update(T item);

        void Delete(T entity);

        T GetByID(object id);


        IEnumerable<T> GetAll();
        
    }
}
