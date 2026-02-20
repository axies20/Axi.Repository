using System.Linq.Expressions;
using Axi.Repository.Abstractions.Repository;
using Axi.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Base implementation of read-only repository pattern for entities.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
/// <typeparam name="TDbContext">Database context type.</typeparam>
public abstract class BaseReadRepository<T, TDbContext>(TDbContext dbContext) : IBaseReadRepository<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Counts entities matching the predicate.
    /// </summary>
    /// <param name="predicate">Filter condition.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Count of matching entities.</returns>
    public Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().CountAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Counts all entities.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Total entity count.</returns>
    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().CountAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves first entity matching the predicate or null.
    /// </summary>
    /// <param name="predicate">Filter condition.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>First matching entity or null.</returns>
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Retrieves entities matching the predicate.
    /// </summary>
    /// <param name="predicate">Filter condition.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of matching entities.</returns>
    public Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves paginated entities matching the predicate.
    /// </summary>
    /// <param name="predicate">Filter condition.</param>
    /// <param name="request">Pagination parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paginated result.</returns>
    public async Task<PagedResult<T>> ListAsync(Expression<Func<T, bool>> predicate, PageRequest request,
        CancellationToken cancellationToken = default)
    {
        var query = dbContext.Set<T>().Where(predicate);

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>(items, totalCount, request.Page, request.PageSize);
    }

    /// <summary>
    /// Asynchronously determines whether any entities in the repository satisfy the provided predicate.
    /// </summary>
    /// <param name="predicate">
    /// A function to test each entity for a condition.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a boolean value indicating whether any entities match the predicate.
    /// </returns>
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().AnyAsync(predicate, cancellationToken);
    }
}