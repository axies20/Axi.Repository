using Axi.Repository.Abstractions.Repository;
using Axi.Repository.Models;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Repository;

/// <summary>
/// Defines read-only repository operations supporting query specifications for entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity managed by the repository.</typeparam>
public interface ISpecificationReadRepository<T> : IBaseReadRepository<T> where T : class
{
    /// <summary>
    /// Asynchronously counts the total number of entities that satisfy the specified criteria.
    /// </summary>
    /// <param name="specification">
    /// The specification containing the filtering criteria to determine which entities
    /// should be counted. This includes conditions, include paths, and any additional
    /// query behavior.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to propagate notification that the operation
    /// should be canceled. This parameter is optional and defaults to <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the total count
    /// of entities that match the given specification.
    /// </returns>
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the first entity that matches the specified query criteria or returns the default value if no match is found.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="specification">
    /// The specification that defines the query criteria, including filters, sorting, and include paths.
    /// </param>
    /// <param name="cancellationToken">
    /// A cancellation token that can be used to cancel the operation. This parameter is optional and defaults to <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the first entity that matches
    /// the specified criteria, or <c>null</c> if no matches are found.
    /// </returns>
    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of entities that satisfy the specified query criteria.
    /// The query behavior is defined by the provided specification, such as filters,
    /// include paths for eager loading, ordering, and other query execution strategies.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    /// <param name="specification">
    /// The specification containing the query criteria and additional query behavior
    /// to apply when retrieving the entities.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests. The default value is <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains a list of entities
    /// that match the criteria defined in the specification.
    /// </returns>
    Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a paginated list of entities that match the given specification.
    /// </summary>
    /// <param name="specification">The specification defining the criteria, sorting, and includes to apply when retrieving the entities.</param>
    /// <param name="pageRequest">The paging parameters which include the page number and size for the result set.</param>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>A <see cref="PagedResult{T}"/> containing the matching entities and pagination details.</returns>
    Task<PagedResult<T>> ListAsync(ISpecification<T> specification, PageRequest pageRequest,
        CancellationToken cancellationToken = default);
}