using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Repository;

/// <summary>
/// Provides deferred Entity Framework queries configured by specifications.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface ISpecificationQuerySource<T> where T : class
{
    /// <summary>
    /// Creates a query for all entities or applies the supplied specification.
    /// </summary>
    /// <param name="specification">The optional specification to apply.</param>
    /// <returns>A deferred query that has not yet been executed.</returns>
    IQueryable<T> Query(ISpecification<T>? specification = null);
}
