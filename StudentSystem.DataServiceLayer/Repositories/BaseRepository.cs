using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentSystem.DataServiceLayer;

namespace StudentSystem.DataServiceLayer
{
    /// <summary>
    /// The base repository for the database.
    /// </summary>
    /// <typeparam name="TEntity">The entity used as an object to save to database or load from the database.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DbContext mContext;

        public BaseRepository(DbContext context)
        {
            this.mContext = context;
        }

        public TEntity GetById(int id)
        {
            return mContext.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await mContext.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return mContext.Set<TEntity>().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await mContext.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicateExpression)
        {
            return mContext.Set<TEntity>().Where(predicateExpression);
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicateExpression)
        {
            return await mContext.Set<TEntity>().Where(predicateExpression).ToListAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicateExpression)
        {
            return mContext.Set<TEntity>().SingleOrDefault(predicateExpression);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicateExpression)
        {
            return await mContext.Set<TEntity>().SingleOrDefaultAsync(predicateExpression);
        }

        public void Add(TEntity entity)
        {
            mContext.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await mContext.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            mContext.Set<TEntity>().AddRange(entities);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await mContext.Set<TEntity>().AddRangeAsync(entities);
        }

        /// <summary>
        /// Updates the <see cref="TEntity"/> in the database.
        /// </summary>
        /// <param name="entity">The entity itself as updated version.</param>
        public void Update(TEntity entity)
        {
            mContext.Update(entity);
        }

        /// <summary>
        /// Updates the <see cref="TEntity"/> in the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity itself as updated version.</param>
        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() =>
            { 
                mContext.Update(entity);
            });
        }

        public void Remove(TEntity entity)
        {
            mContext.Set<TEntity>().Remove(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => mContext.Set<TEntity>().Remove(entity));
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            mContext.Set<TEntity>().RemoveRange(entities);
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => mContext.Set<TEntity>().RemoveRange(entities));
        }
    }
}
