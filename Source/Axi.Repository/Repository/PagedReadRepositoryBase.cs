using System.Linq.Expressions;
using Axi.Repository.Abstractions.Repository;
using Axi.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Base implementation of offset-based pagination for entities.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context used to query entities.</param>
public abstract class PagedReadRepositoryBase<T, TDbContext>(TDbContext dbContext)
    : ReadRepositoryBase<T, TDbContext>(dbContext),
        IPagedReadRepository<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Applies deterministic ordering before offset pagination.
    /// </summary>
    /// <param name="query">The filtered query to order.</param>
    /// <returns>The deterministically ordered query.</returns>
    protected abstract IOrderedQueryable<T> OrderByPage(IQueryable<T> query);

    /// <inheritdoc />
    public async Task<PagedResult<T>> ListAsync(
        Expression<Func<T, bool>> predicate,
        PageRequest pageRequest,
        CancellationToken cancellationToken = default)
    {
        var query = DbContext.Set<T>().Where(predicate);
        var totalCount = await query.CountAsync(cancellationToken);

        var items = await OrderByPage(query)
            .Skip((pageRequest.Page - 1) * pageRequest.PageSize)
            .Take(pageRequest.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>(
            items,
            totalCount,
            pageRequest.Page,
            pageRequest.PageSize);
    }
}
