using System.Linq.Expressions;

namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Provides deferred Entity Framework queries for an entity type.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
public interface IQuerySource<T> where T : class
{
    /// <summary>
    /// Creates a query for all entities or applies the supplied predicate.
    /// </summary>
    /// <param name="predicate">The optional filter predicate.</param>
    /// <returns>A deferred query that has not yet been executed.</returns>
    IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null);
}
