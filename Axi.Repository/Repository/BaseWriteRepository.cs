using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Base implementation of write operations for entities.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
/// <typeparam name="TDbContext">Database context type.</typeparam>
public class BaseWriteRepository<T, TDbContext>(TDbContext dbContext) : IBaseWriteRepository<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Adds an entity.
    /// </summary>
    /// <param name="entity">Entity to add.</param>
    public void Add(T entity)
    {
        dbContext.Set<T>().Add(entity);
    }

    /// <summary>
    /// Adds an entity asynchronously.
    /// </summary>
    /// <param name="entity">Entity to add.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task AddAsync(T entity, CancellationToken ct)
    {
        return dbContext.Set<T>().AddAsync(entity, ct).AsTask();
    }

    /// <summary>
    /// Adds multiple entities asynchronously.
    /// </summary>
    /// <param name="entities">Entities to add.</param>
    /// <param name="ct">Cancellation token.</param>
    public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct)
    {
        return dbContext.Set<T>().AddRangeAsync(entities, ct);
    }

    /// <summary>
    /// Adds multiple entities.
    /// </summary>
    /// <param name="entities">Entities to add.</param>
    public void AddRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().AddRange(entities);
    }

    /// <summary>
    /// Updates an entity.
    /// </summary>
    /// <param name="entity">Entity to update.</param>
    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
    }

    /// <summary>
    /// Updates multiple entities.
    /// </summary>
    /// <param name="entities">Entities to update.</param>
    public void UpdateRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().UpdateRange(entities);
    }

    /// <summary>
    /// Deletes an entity.
    /// </summary>
    /// <param name="entity">Entity to delete.</param>
    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }
}