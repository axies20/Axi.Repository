using System.Linq.Expressions;
using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Base implementation of a deferred Entity Framework query source.
/// </summary>
/// <typeparam name="T">The entity type.</typeparam>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context used to create queries.</param>
public abstract class QuerySourceBase<T, TDbContext>(TDbContext dbContext) : IQuerySource<T>
    where T : class
    where TDbContext : DbContext
{
    /// <summary>
    /// Gets the database context used by the query source.
    /// </summary>
    protected TDbContext DbContext { get; } = dbContext;

    /// <inheritdoc />
    public IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null)
    {
        var query = DbContext.Set<T>();
        return predicate is null ? query : query.Where(predicate);
    }
}
