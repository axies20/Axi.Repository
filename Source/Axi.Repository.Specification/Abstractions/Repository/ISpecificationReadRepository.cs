using Axi.Repository.Abstractions.Repository;
using Axi.Repository.Models;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Repository;

/// <summary>
/// Defines read-only repository operations driven by query specifications.
/// </summary>
/// <typeparam name="T">The type of entity managed by the repository.</typeparam>
public interface ISpecificationReadRepository<T> : IReadRepository<T> where T : class
{
    /// <summary>
    /// Asynchronously counts entities matching the specification's filter criteria.
    /// </summary>
    /// <param name="specification">The specification whose filter criteria are applied.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The number of matching entities.</returns>
    Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves the first entity matching the specification.
    /// </summary>
    /// <param name="specification">The specification to apply.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The first matching entity, or <see langword="null"/> when no match exists.</returns>
    Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves all entities matching the specification.
    /// </summary>
    /// <param name="specification">The specification to apply.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A list containing the matching entities.</returns>
    Task<List<T>> ListAsync(ISpecification<T> specification, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves one offset-based page of entities matching the specification.
    /// </summary>
    /// <param name="specification">The specification to apply.</param>
    /// <param name="pageRequest">The pagination parameters.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A page of matching entities together with pagination metadata.</returns>
    /// <remarks>
    /// The specification should define a stable ordering when results span multiple pages.
    /// </remarks>
    Task<PagedResult<T>> ListAsync(ISpecification<T> specification, PageRequest pageRequest,
        CancellationToken cancellationToken = default);
}
