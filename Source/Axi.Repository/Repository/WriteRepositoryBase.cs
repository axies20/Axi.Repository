using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Entity Framework Core base implementation of repository write operations.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context that tracks entity changes.</param>
public abstract class WriteRepositoryBase<T, TDbContext>(TDbContext dbContext) : IWriteRepository<T>
    where T : class
    where TDbContext : DbContext
{
    /// <inheritdoc />
    public void Add(T entity)
    {
        dbContext.Set<T>().Add(entity);
    }

    /// <inheritdoc />
    public Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().AddAsync(entity, cancellationToken).AsTask();
    }

    /// <inheritdoc />
    public Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        return dbContext.Set<T>().AddRangeAsync(entities, cancellationToken);
    }

    /// <inheritdoc />
    public void AddRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().AddRange(entities);
    }

    /// <inheritdoc />
    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
    }

    /// <inheritdoc />
    public void UpdateRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().UpdateRange(entities);
    }

    /// <inheritdoc />
    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }

    /// <inheritdoc />
    public void DeleteRange(IEnumerable<T> entities)
    {
        dbContext.Set<T>().RemoveRange(entities);
    }
}
