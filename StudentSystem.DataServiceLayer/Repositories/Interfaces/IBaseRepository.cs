using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.DataServiceLayer
{
    /// <summary>
    /// The base repository interface for all repositories.
    /// <br/>
    /// Provides all needed operation as retrieving, updating, inserting or deleting entities.
    /// </summary>
    /// <typeparam name="TEntity">The arbitrary entity that is used in the repository.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Retrieves the entity from the storage medium (database, text file, xml, etc.) by given ID.
        /// </summary>
        /// <param name="id">The identifier of the Entity.</param>
        TEntity GetById(int id);

        /// <summary>
        /// Retrieves the entity from the storage medium asynchronously by given ID.
        /// </summary>
        /// <param name="id">The identifier of the Entity.</param>
        Task<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Retrieves the <see cref="IQueryable{TEntity}"/> of the <see cref="TEntity"/> class.
        /// </summary>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Retrieves the <see cref="IQueryable{TEntity}"/> of the <see cref="TEntity"/> class asynchronously.
        /// </summary>
        Task<IQueryable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieves the <see cref="IQueryable{TEntity}"/> of the <see cref="TEntity"/> class by the given predicate logic.
        /// </summary>
        /// <param name="predicateExpression">The predicate expression that tells what entities will be retrieved.</param>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicateExpression);

        /// <summary>
        /// Retrieves the <see cref="IQueryable{TEntity}"/> of the <see cref="TEntity"/> class by the given predicate logic asynchronously.
        /// </summary>
        /// <param name="predicateExpression">The predicate expression that tells what entities will be retrieved.</param>
        Task<IQueryable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicateExpression);

        /// <summary>
        /// Retrieves a single entity by the given predicate logic.
        /// </summary>
        /// <param name="predicateExpression">The predicate expression that tells what entities will be retrieved.</param>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicateExpression);

        /// <summary>
        /// Retrieves a single entity by the given predicate logic asynchronously.
        /// </summary>
        /// <param name="predicateExpression">The predicate expression that tells what entities will be retrieved.</param>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicateExpression);

        /// <summary>
        /// Adds the <see cref="TEntity"/> into the repository.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> class.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds the <see cref="TEntity"/> into the repository asynchronously.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> class.</param>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Adds an collection of entities into the repository.
        /// </summary>
        /// <param name="entities">The collection of entities.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Adds an collection of entities into the repository asynchronously.
        /// </summary>
        /// <param name="entities">The collection of entities.</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates given entity in the repository by the entity identified by its ID.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates given entity in the repository by the entity identified by its ID asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Removes the <see cref="TEntity"/> from the repository.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be removed.</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes the <see cref="TEntity"/> from the repository.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> to be removed.</param>
        Task RemoveAsync(TEntity entity);

        /// <summary>
        /// Removes a collection of <see cref="TEntity"/> from the repository.
        /// </summary>
        /// <param name="entities">The collection of <see cref="TEntity"/>.</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes a collection of <see cref="TEntity"/> from the repository asynchronously.
        /// </summary>
        /// <param name="entities">The collection of <see cref="TEntity"/>.</param>
        Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    }
}
