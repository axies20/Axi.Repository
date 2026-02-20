using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Base implementation of unit of work pattern.
/// </summary>
/// <typeparam name="TDbContext">Database context type.</typeparam>
public class BaseUnitOfWork<TDbContext>(TDbContext dbContext) : IBaseUnitOfWork where TDbContext : DbContext
{
    /// <summary>
    /// Releases database context resources.
    /// </summary>
    public virtual void Dispose()
    {
        dbContext.Dispose();
    }

    /// <summary>
    /// Releases database context resources asynchronously.
    /// </summary>
    public virtual ValueTask DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }

    /// <summary>
    /// Saves all changes to the database.
    /// </summary>
    public void SaveChanges()
    {
        dbContext.SaveChanges();
    }

    /// <summary>
    /// Saves all changes to the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Number of state entries written.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}