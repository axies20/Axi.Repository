using Axi.Repository.Models;
using Axi.Repository.Repository;
using Axi.Repository.Specification.Abstractions.Repository;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Repository;

/// <summary>
/// Provides methods for reading data from a database context using specifications to filter, sort, and paginate data.
/// Extends the base read repository functionality with support for specification-based queries.
/// </summary>
/// <typeparam name="T">The type of the entity for which the repository is responsible.</typeparam>
/// <typeparam name="TDbContext">
/// The type of the database context used to interact with the underlying data source. Must derive from DbContext.
/// </typeparam>
public class SpecificationReadRepository<T, TDbContext>(TDbContext dbContext)
    : BaseReadRepository<T, TDbContext>(dbContext), ISpecificationReadRepository<T> where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Represents the database context used for accessing and interacting with the underlying database.
    /// This instance provides methods to query and manipulate entities in a specific database
    /// through the Entity Framework Core API. It is used internally for executing queries and
    /// applying specifications related to the <typeparamref name="T"/> entities.
    /// </summary>
    private readonly TDbContext _dbContext = dbContext;

    /// <summary>
    /// Asynchronously counts the number of entities that satisfy the given specification.
    /// </summary>
    /// <param name="specification">
    /// The specification defining the criteria to filter the entities.
    /// </param>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation, containing the count of entities that match the specification.
    /// </returns>
    public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.ApplyCriteriaOnly(_dbContext.Set<T>(), specification)
            .CountAsync(cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves the first entity from the data source that matches the criteria defined
    /// in the provided specification. If no such entity is found, null is returned.
    /// </summary>
    /// <param name="specification">
    /// An object implementing <see cref="ISpecification{T}"/>, which defines the filtering, ordering,
    /// and inclusion logic to apply when querying the data source.
    /// </param>
    /// <param name="cancellationToken">
    /// A <see cref="CancellationToken"/> that can be used to propagate notifications that
    /// the operation should be canceled.
    /// </param>
    /// <return>
    /// A task that represents the asynchronous operation. The task result contains the first entity
    /// that matches the specification, or null if no matching entity is found.
    /// </return>
    public Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.Apply(_dbContext.Set<T>(), specification)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves a list of entities that satisfy the given specification.
    /// </summary>
    /// <param name="specification">The specification defining the filtering, ordering, and inclusion rules to be applied when querying the entities.</param>
    /// <param name="cancellationToken">An optional token to observe for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a list of entities matching the given specification.</returns>
    public Task<List<T>> ListAsync(ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.Apply(_dbContext.Set<T>(), specification).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves a paginated list of entities that match the provided specification.
    /// </summary>
    /// <param name="specification">The specification to filter entities.</param>
    /// <param name="pageRequest">The pagination details, including page number and page size.</param>
    /// <param name="ct">Optional cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="PagedResult{T}"/> containing the paginated list of entities and pagination metadata.</returns>
    public async Task<PagedResult<T>> ListAsync(ISpecification<T> specification, PageRequest pageRequest,
        CancellationToken ct = default)
    {
        var set = _dbContext.Set<T>();

        var totalCount = await EfSpecificationEvaluator.ApplyCriteriaOnly(set, specification)
            .CountAsync(ct);

        var items = await EfSpecificationEvaluator.Apply(set, specification)
            .Skip((pageRequest.Page - 1) * pageRequest.PageSize)
            .Take(pageRequest.PageSize)
            .ToListAsync(ct);

        return new PagedResult<T>(items, totalCount, pageRequest.Page, pageRequest.PageSize);
    }
}