using Axi.Repository.Abstractions.Repository;
using Axi.Repository.Models;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Repository;

/// <summary>
/// Read-only repository with specification support.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public interface ISpecificationReadRepository<T> : IBaseReadRepository<T> where T : class
{
    /// <summary>
    /// Counts entities matching the specification.
    /// </summary>
    /// <param name="specification">Filter specification.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Count of matching entities.</returns>
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves first entity matching the specification or null.
    /// </summary>
    /// <param name="specification">Query specification.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>First matching entity or null.</returns>
    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves entities matching the specification.
    /// </summary>
    /// <param name="specification">Query specification.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of matching entities.</returns>
    Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves paginated entities matching the specification.
    /// </summary>
    /// <param name="specification">Query specification.</param>
    /// <param name="pageRequest">Pagination parameters.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Paginated result.</returns>
    Task<PagedResult<T>> ListAsync(ISpecification<T> specification, PageRequest pageRequest,
        CancellationToken cancellationToken = default);
}