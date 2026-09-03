using System.Linq.Expressions;
using Axi.Repository.Models;

namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Defines read operations using cursor-based keyset pagination.
/// </summary>
/// <typeparam name="T">The type of the entity managed by the repository.</typeparam>
/// <typeparam name="TCursor">The value type that uniquely identifies a cursor position.</typeparam>
public interface ICursorReadRepository<T, TCursor> : IReadRepository<T>
    where T : class
    where TCursor : struct
{
    /// <summary>
    /// Retrieves one page of entities after the supplied cursor.
    /// </summary>
    /// <param name="predicate">
    /// A filter expression to determine which entities should be included in the result set.
    /// </param>
    /// <param name="request">
    /// The cursor-based pagination request, which specifies the cursor position and the number of items to retrieve.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A task whose result contains the current page and the cursor for the next page, if one exists.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <see cref="CursorRequest{TCursor}.Size"/> is less than one.
    /// </exception>
    Task<CursorResult<T, TCursor>> ListAsync(Expression<Func<T, bool>> predicate, CursorRequest<TCursor> request,
        CancellationToken cancellationToken = default);
}
