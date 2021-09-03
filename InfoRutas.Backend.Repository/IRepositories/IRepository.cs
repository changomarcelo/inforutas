using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InfoRutas.Backend.Repository
{
    public interface IRepository<T>
    {
        T Create(T entity);
        T Find(int id);
        T Find(Expression<Func<T, bool>> condition);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);
        void Update(T entity);
        void Delete(T entity);

        Task<T> CreateAsync(T entity);
        Task<T> FindAsync(int id);
        Task<T> FindAsync(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        Task<int> CountCriteriaAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllPagedAsync(Expression<Func<T, bool>> filter,
                                        Expression<Func<T, object>> orderBy = null,
                                        bool orderAscending = true,
                                        int? skip = null,
                                        int? take = null);
    }
}
