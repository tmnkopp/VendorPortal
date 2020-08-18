using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VendorPortal.Models
{ 
    public interface IRepository<T> where T : class
    { 
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T GetById(object id);
        IQueryable<T> Table { get; }
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    } 
}
