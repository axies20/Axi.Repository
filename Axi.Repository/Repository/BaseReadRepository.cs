using System.Linq.Expressions;
using Axi.Repository.Abstractions.Repository;
using Axi.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// A base class that implements the read-only repository pattern for accessing and querying entities.
/// </summary>
/// <typeparam name="T">
/// The type of the entity being operated on.
/// </typeparam>
/// <typeparam name="TDbContext">
/// The type of the database context used for querying the database.
/// Must inherit from <see cref="DbContext"/>.
/// </typeparam>
public class BaseReadRepository<T, TDbContext>(TDbContext dbContext) : IBaseReadRepository<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Asynchronously counts the number of entities in the repository matching the given predicate.
    /// </summary>
    /// <param name="predicate">
    /// A function to test each entity for a condition.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the count of entities matching the predicate.
    /// </returns>
    public Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().CountAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously counts the total number of entities in the repository.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the total number of entities in the repository.
    /// </returns>
    public Task<int> CountAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().CountAsync(cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the first entity from the repository that matches the specified predicate, or null if no such entity is found.
    /// </summary>
    /// <param name="predicate">
    /// A function to test each entity for a condition.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the first matching entity or null if no match is found.
    /// </returns>
    public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves a list of entities from the repository that match the specified predicate.
    /// </summary>
    /// <param name="predicate">
    /// A function to test each entity for a condition.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of entities that match the predicate.
    /// </returns>
    public Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return dbContext.Set<T>().Where(predicate).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves a paginated list of entities from the repository
    /// that match the specified predicate.
    /// </summary>
    /// <param name="predicate">
    /// An expression used to filter the entities.
    /// </param>
    /// <param name="request">
    /// The pagination details, including page number and page size.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// a paged result, including the list of entities, total count, page number,
    /// and page size.
    /// </returns>
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