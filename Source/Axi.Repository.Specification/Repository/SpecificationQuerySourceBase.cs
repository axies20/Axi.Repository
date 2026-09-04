using Axi.Repository.Specification.Abstractions.Repository;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Repository;

/// <summary>
/// Base implementation of a deferred query source configured by specifications.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context used to create queries.</param>
public abstract class SpecificationQuerySourceBase<T, TDbContext>(TDbContext dbContext)
    : ISpecificationQuerySource<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Gets the database context used by the query source.
    /// </summary>
    protected TDbContext DbContext { get; } = dbContext;

    /// <inheritdoc />
    public IQueryable<T> Query(ISpecification<T>? specification = null)
        => EfSpecificationEvaluator.Apply(DbContext.Set<T>(), specification);
}
