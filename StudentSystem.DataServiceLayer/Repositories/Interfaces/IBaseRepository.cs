using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DataServiceLayer.Repositories.Interfaces
{
    /// <summary>
    /// The base repository interface for all repositories.
    /// </summary>
    /// <typeparam name="TEntity">The arbitrary entity that is used in the repository.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicateExpression);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicateExpression);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicateExpression);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicateExpression);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        Task RemoveAsync(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
