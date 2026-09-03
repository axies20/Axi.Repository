using Axi.Repository.Models;
using Axi.Repository.Repository;
using Axi.Repository.Specification.Abstractions.Repository;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Repository;

/// <summary>
/// Entity Framework Core base implementation of specification-based read operations.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context used to evaluate specifications.</param>
public abstract class SpecificationReadRepositoryBase<T, TDbContext>(TDbContext dbContext)
    : ReadRepositoryBase<T, TDbContext>(dbContext), ISpecificationReadRepository<T> where T : class
    where TDbContext : DbContext
{
    /// <inheritdoc />
    public Task<int> CountAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.ApplyCriteriaOnly(DbContext.Set<T>(), specification)
            .CountAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task<T?> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.Apply(DbContext.Set<T>(), specification)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc />
    public Task<List<T>> ListAsync(ISpecification<T> specification,
        CancellationToken cancellationToken = default)
    {
        return EfSpecificationEvaluator.Apply(DbContext.Set<T>(), specification).ToListAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<PagedResult<T>> ListAsync(ISpecification<T> specification, PageRequest pageRequest,
        CancellationToken cancellationToken = default)
    {
        var set = DbContext.Set<T>();

        var totalCount = await EfSpecificationEvaluator.ApplyCriteriaOnly(set, specification)
            .CountAsync(cancellationToken);

        var items = await EfSpecificationEvaluator.Apply(set, specification)
            .Skip((pageRequest.Page - 1) * pageRequest.PageSize)
            .Take(pageRequest.PageSize)
            .ToListAsync(cancellationToken);

        return new PagedResult<T>(items, totalCount, pageRequest.Page, pageRequest.PageSize);
    }
}
