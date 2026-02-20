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
    /// Asynchronously counts the number of entities that satisfy a specified condition.
    /// </summary>
    /// <param name="predicate">
    /// A lambda expression to filter the entities based on a specified condition.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// The task that represents the asynchronous count operation. The task result contains the number of entities that match the specified condition.
    /// </returns>
    Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously counts the total number of entities in the repository.
    /// </summary>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to cancel the operation before it completes.
    /// </param>
    /// <returns>
    /// The total count of entities in the repository as a task result.
    /// </returns>
    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// Retrieves the first element of a sequence that satisfies a specified condition or a default value if no such element exists.
    /// <param name="predicate">
    /// A function to test each element for a condition.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the first element in the sequence
    /// that satisfies the condition specified by <paramref name="predicate"/>, or the default value of type <typeparamref name="T"/> if no such element is found.
    /// </returns>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    /// Asynchronously retrieves a list of entities from the data source that match the specified predicate.
    /// <param name="predicate">
    /// An expression that defines the conditions of the entities to be retrieved.
    /// </param>
    /// <param name="cancellationToken">
    /// A CancellationToken to observe while waiting for the task to complete. Optional, defaults to CancellationToken.None.
    /// </param>
    /// <returns>
    /// A Task that represents the asynchronous operation. The task result contains a list of entities that satisfy the predicate.
    /// </returns>
    Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    /// Retrieves a paged list of entities matching the given predicate.
    /// <param name="predicate">
    /// A LINQ expression used to filter the entities.
    /// </param>
    /// <param name="pageRequest">
    /// The paging parameters, including the page number and page size.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to cancel the async operation if needed.
    /// </param>
    /// <returns>
    /// A paged result containing the list of items that match the predicate,
    /// along with additional paging information such as total count, current page, and page size.
    /// </returns>
    Task<PagedResult<T>> ListAsync(Expression<Func<T, bool>> predicate, PageRequest pageRequest,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Determines whether any elements in the data source satisfy the specific condition defined by the predicate.
    /// </summary>
    /// <param name="predicate">A function to test each item for a condition.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation.
    /// The task result contains a boolean value: true if any elements satisfy the condition; otherwise, false.
    /// </returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}