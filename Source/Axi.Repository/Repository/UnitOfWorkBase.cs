using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Base implementation that saves changes and owns the lifetime of a database context.
/// </summary>
/// <typeparam name="TDbContext">The Entity Framework database context type.</typeparam>
/// <param name="dbContext">The database context owned by this unit of work.</param>
public abstract class UnitOfWorkBase<TDbContext>(TDbContext dbContext) : IUnitOfWork where TDbContext : DbContext
{
    /// <inheritdoc />
    public virtual void Dispose()
    {
        dbContext.Dispose();
    }

    /// <inheritdoc />
    public virtual ValueTask DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }

    /// <inheritdoc />
    public void SaveChanges()
    {
        dbContext.SaveChanges();
    }

    /// <inheritdoc />
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}
