using Axi.Repository.Models;
using Axi.Repository.Repository;
using Axi.Repository.Specification.Abstractions.Repository;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Repository;

/// <summary>
/// Read repository with specification support.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
/// <typeparam name="TDbContext">Database context type.</typeparam>
public abstract class SpecificationReadRepository<T, TDbContext>(TDbContext dbContext)
    : BaseReadRepository<T, TDbContext>(dbContext), ISpecificationReadRepository<T> where T : class
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext = dbContext;

    /// <summary>
    /// Counts entities matching the specification.
    /// </summary>
    /// <param name="specification">Filter specification.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Count of matching entities.</returns>
    public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.ApplyCriteriaOnly(_dbContext.Set<T>(), specification)
            .CountAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves first entity matching the specification or null.
    /// </summary>
    /// <param name="specification">Query specification.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>First matching entity or null.</returns>
    public Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.Apply(_dbContext.Set<T>(), specification)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves entities matching the specification.
    /// </summary>
    /// <param name="specification">Query specification.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>List of matching entities.</returns>
    public Task<List<T>> ListAsync(ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.Apply(_dbContext.Set<T>(), specification).ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves paginated entities matching the specification.
    /// </summary>
    /// <param name="specification">Query specification.</param>
    /// <param name="pageRequest">Pagination parameters.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>Paginated result.</returns>
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