using System.Linq.Expressions;
using Axi.Repository.Abstractions.Repository;
using Axi.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Base implementation of cursor-based pagination for entities.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TCursor">The value type that uniquely identifies a cursor position.</typeparam>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context used to query entities.</param>
public abstract class CursorReadRepositoryBase<T, TCursor, TDbContext>(TDbContext dbContext)
    : ReadRepositoryBase<T, TDbContext>(dbContext),
        ICursorReadRepository<T, TCursor>
    where T : class
    where TCursor : struct
    where TDbContext : DbContext
{
    /// <summary>
    /// Applies the exclusive cursor boundary to the query.
    /// </summary>
    /// <param name="query">The filtered query to constrain.</param>
    /// <param name="cursor">The cursor returned by the preceding page.</param>
    /// <returns>The query constrained to entities after the cursor.</returns>
    protected abstract IQueryable<T> ApplyAfter(IQueryable<T> query, TCursor cursor);

    /// <summary>
    /// Applies the deterministic ordering represented by the cursor.
    /// </summary>
    /// <param name="query">The query to order.</param>
    /// <returns>The deterministically ordered query.</returns>
    protected abstract IOrderedQueryable<T> OrderByCursor(IQueryable<T> query);

    /// <summary>
    /// Creates a cursor for an entity returned to the caller.
    /// </summary>
    /// <param name="entity">The last entity in the current page.</param>
    /// <returns>The cursor used to request the following page.</returns>
    protected abstract TCursor GetCursor(T entity);

    /// <inheritdoc />
    public async Task<CursorResult<T, TCursor>> ListAsync(
        Expression<Func<T, bool>> predicate,
        CursorRequest<TCursor> request,
        CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(request.Size, 1);

        var query = DbContext.Set<T>()
            .Where(predicate);

        if (request.After is { } cursor)
        {
            query = ApplyAfter(query, cursor);
        }

        var items = await OrderByCursor(query)
            .Take(request.Size + 1)
            .ToListAsync(cancellationToken);

        var hasMore = items.Count > request.Size;

        if (hasMore)
        {
            items.RemoveAt(request.Size);
        }

        return new CursorResult<T, TCursor>(
            items,
            hasMore ? GetCursor(items[^1]) : null);
    }
}
