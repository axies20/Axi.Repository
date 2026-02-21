using System.Linq.Expressions;
using Axi.Repository.Models;

namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Represents a base contract for read-only repository operations.
/// </summary>
/// <typeparam name="T">The type of the entity managed by the repository.</typeparam>
public interface IBaseReadRepository<T> where T : class
{
    /// <summary>
    /// Asynchronously counts the number of entities that satisfy the specified condition.
    /// </summary>
    /// <param name="predicate">A lambda expression to filter entities.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The number of entities that match the condition.</returns>
    Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously counts the total number of entities in the repository.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The total count of entities.</returns>
    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves the first entity that satisfies the specified condition, or null if none found.
    /// </summary>
    /// <param name="predicate">A function to test each entity for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The first matching entity, or null if no match is found.</returns>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a list of entities that match the specified condition.
    /// </summary>
    /// <param name="predicate">An expression that defines the filter condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A list of entities that satisfy the condition.</returns>
    Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a paginated list of entities matching the specified condition.
    /// </summary>
    /// <param name="predicate">A LINQ expression to filter entities.</param>
    /// <param name="pageRequest">The pagination parameters.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A paginated result containing matching entities and pagination metadata.</returns>
    Task<PagedResult<T>> ListAsync(Expression<Func<T, bool>> predicate, PageRequest pageRequest,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously determines whether any entities satisfy the specified condition.
    /// </summary>
    /// <param name="predicate">A function to test each entity for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>True if any entities satisfy the condition; otherwise, false.</returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}