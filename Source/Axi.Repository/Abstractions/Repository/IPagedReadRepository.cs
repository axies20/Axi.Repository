using System.Linq.Expressions;
using Axi.Repository.Models;

namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Defines read operations using offset-based pagination.
/// </summary>
/// <typeparam name="T">The type of the entity managed by the repository.</typeparam>
public interface IPagedReadRepository<T> : IReadRepository<T> where T : class
{
    /// <summary>
    /// Retrieves one deterministically ordered page of entities matching the predicate.
    /// </summary>
    /// <param name="predicate">A LINQ expression to filter entities.</param>
    /// <param name="pageRequest">The pagination parameters.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A paginated result containing matching entities and pagination metadata.</returns>
    /// <remarks>Implementations must apply a stable ordering before skipping entities.</remarks>
    Task<PagedResult<T>> ListAsync(Expression<Func<T, bool>> predicate, PageRequest pageRequest,
        CancellationToken cancellationToken = default);
}
