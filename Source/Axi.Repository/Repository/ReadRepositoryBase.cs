using System.Linq.Expressions;
using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Entity Framework Core base implementation of read-only repository operations.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context used to query entities.</param>
public abstract class ReadRepositoryBase<T, TDbContext>(TDbContext dbContext) : IReadRepository<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Gets the database context used by derived repositories.
    /// </summary>
    protected TDbContext DbContext { get; } = dbContext;

    /// <inheritdoc />
    public Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return DbContext.Set<T>().CountAsync(predicate, cancellationToken);
    }

    /// <inheritdoc />
    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.Set<T>().CountAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task<long> LongCountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return DbContext.Set<T>().LongCountAsync(predicate, cancellationToken);
    }

    /// <inheritdoc />
    public Task<long> LongCountAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.Set<T>().LongCountAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return DbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    /// <inheritdoc />
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return DbContext.Set<T>().AnyAsync(predicate, cancellationToken);
    }
}
