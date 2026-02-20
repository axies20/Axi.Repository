using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Provides the implementation of write operations for a repository managing entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the entity managed by the repository.</typeparam>
/// <typeparam name="TDbContext">The type of the database context.</typeparam>
public class BaseWriteRepository<T, TDbContext>(TDbContext dbContext) : IBaseWriteRepository<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Adds a single entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to be added to the repository.</param>
    public void Add(T entity)
    {
        dbContext.Set<T>().Add(entity);
    }

    /// <summary>
    /// Adds an entity to the data store asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add to the data store.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task AddAsync(T entity, CancellationToken ct)
    {
        return dbContext.Set<T>().AddAsync(entity, ct).AsTask();
    }

    /// <summary>
    /// Asynchronously adds a collection of entities to the repository.
    /// </summary>
    /// <param name="entities">
    /// The collection of entities to be added to the repository.
    /// </param>
    /// <param name="ct">
    /// A cancellation token to monitor for request cancellation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation of adding the collection of entities.
    /// </returns>
    public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct)
    {
        return dbContext.Set<T>().AddRangeAsync(entities, ct);
    }

    /// <summary>
    /// Adds a collection of entities to the repository.
    /// </summary>
    /// <param name="entities">
    /// The collection of entities to add to the repository.
    /// </param>
    public void AddRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().AddRange(entities);
    }

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
    }

    /// <summary>
    /// Updates a collection of entities in the repository.
    /// </summary>
    /// <param name="entities">
    /// A collection of entities to be updated in the repository. Each entity in the collection will be tracked and marked for update.
    /// </param>
    public void UpdateRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().UpdateRange(entities);
    }

    /// <summary>
    /// Removes the specified entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to be removed from the repository.</param>
    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }
}