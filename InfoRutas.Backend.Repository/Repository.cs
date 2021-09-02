using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InfoRutas.Backend.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InfoRutasDbContext _context;
        public readonly ILogger _logger;
        internal DbSet<T> dbSet;

        public Repository(InfoRutasDbContext context, ILogger logger)
        {
            this._context = context;
            this._logger = logger;
            this.dbSet = context.Set<T>();
        }

        /// <summary>
        /// Creates a new Entity
        /// </summary>
        /// <param name="entity">New Entity to create</param>
        /// <returns>Returns the newly created entity</returns>
        public virtual T Create(T entity)
        {
            //entity.CreatedBy = GetCurrentUser();
            return dbSet.Add(entity).Entity;
        }

        /// <summary>
        /// Finds a single Entity by its Primary Key
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>Entity found; otherwise, null</returns>
        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Finds a single Entity that matches a condition. If more than one
        /// element satisfies the condition, an InvalidOperationException is
        /// thrown.
        /// </summary>
        /// <param name="condition">Condition to meet</param>
        /// <returns>Entity found; otherwise, null</returns>
        public T Find(Expression<Func<T, bool>> condition)
        {
            return dbSet.SingleOrDefault(condition);
        }

        /// <summary>
        /// Obtains a list of all the Entities
        /// </summary>
        /// <returns>List of Entities</returns>
        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Obtains a list of all the Entities that match the condition, ordered by the orderBy clause
        /// </summary>
        /// <param name="condition">Option. Condition that entities must meet.</param>
        /// <param name="orderBy">Order clause</param>
        /// <returns>List of Entities</returns>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> condition = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null)
        {
            IQueryable<T> query = dbSet;

            if (condition != null)
                query = query.Where(condition);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        /// <summary>
        /// Deletes a given Entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Updates a given Entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        public virtual void Update(T entity)
        {
            //entity.UpdatedBy = GetCurrentUser();
            dbSet.Update(entity);
        }

        #region Async methods
        /// <summary>
        /// Creates a new Entity asynchronously
        /// </summary>
        /// <param name="entity">New Entity to create</param>
        /// <returns>Returns the newly created entity</returns>
        public virtual async Task<T> CreateAsync(T entity)
        {
            //entity.CreatedBy = GetCurrentUser();
            return (await dbSet.AddAsync(entity)).Entity;
        }

        /// <summary>
        /// Finds a single Entity by its Primary Key asynchronously
        /// </summary>
        /// <param name="id">Primary Key value</param>
        /// <returns>Entity found; otherwise, null</returns>
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        /// <summary>
        /// Finds a single Entity that matches a condition asynchronously. If more than one
        /// element satisfies the condition, an InvalidOperationException is
        /// thrown.
        /// </summary>
        /// <param name="condition">Condition to meet</param>
        /// <returns>Entity found; otherwise, null</returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> condition)
        {
            return await dbSet.SingleOrDefaultAsync(condition);
        }

        /// <summary>
        /// Obtains a list of all the Entities asynchronoulsy
        /// </summary>
        /// <returns>List of Entities</returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        /// <summary>
        /// Obtains a list of all the Entities that match the condition asynchronoulsy, ordered by the orderBy clause
        /// </summary>
        /// <param name="condition">Option. Condition that entities must meet.</param>
        /// <param name="orderBy">Order clause</param>
        /// <returns>List of Entities</returns>
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition = null,
                                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (condition != null)
                query = query.Where(condition);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Returns the count of entities that match a condition asynchronously
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Amount of entities found</returns>
        public async Task<int> CountCriteriaAsync(Expression<Func<T, bool>> filter)
        {
            return await dbSet.Where(filter).CountAsync();
        }

        /// <summary>
        /// Obtains a list of all the Entities that match the condition asynchronoulsy, ordered by the orderBy clause
        /// </summary>
        /// <param name="filter">Filter that entities must meet</param>
        /// <param name="orderBy">Order clause</param>
        /// <param name="orderAscending">True if order ascending is needed; false, otherwise</param>
        /// <param name="skip">Quantity of elements to skip</param>
        /// <param name="take">Quantity of elements to return</param>
        /// <returns>List of entities</returns>
        public async Task<List<T>> GetAllPagedAsync(Expression<Func<T, bool>> filter,
                                                           Expression<Func<T, object>> orderBy = null,
                                                           bool orderAscending = true,
                                                           int? skip = null,
                                                           int? take = null)
        {
            var t = dbSet
                    .Where(filter);

            if (orderBy != null)
                t = orderAscending ? t.OrderBy(orderBy) : t.OrderByDescending(orderBy);

            if (skip.HasValue)
                t = t.Skip(skip.Value);

            if (take.HasValue)
                t = t.Take(take.Value);

            return await t.ToListAsync();
        }

        #endregion

        private string GetCurrentUser()
        {
            throw new NotImplementedException();
        }
    }
}
