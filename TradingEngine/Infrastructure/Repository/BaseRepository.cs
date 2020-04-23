using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TradingEngine.Infrastructure.Repository.Interfaces;

namespace TradingEngine.Infrastructure.Repository
{
    public class TradingEngineRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TradingEngineContext TradingEngineEngineContext;
        protected readonly DbSet<TEntity> DbSet;
        protected readonly DbQuery<TEntity> DbQuery;

        public TradingEngineRepository(TradingEngineContext tradingEngineEngineContext)
        {
            TradingEngineEngineContext = tradingEngineEngineContext;
            DbSet = tradingEngineEngineContext.Set<TEntity>();
            DbQuery = tradingEngineEngineContext.Query<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool enableTracking = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (orderBy != null)
                query = orderBy(query);

            return enableTracking ? query.ToList() : query.AsNoTracking().ToList();
        }

        public void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public int SaveChanges()
        {
            return TradingEngineEngineContext.SaveChanges();
        }
    }
}
