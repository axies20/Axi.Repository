using Axi.Repository.Abstractions.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Repository;

/// <summary>
/// Represents the base implementation of the unit of work pattern, managing the lifecycle of
/// a database context and providing methods to persist changes to the database.
/// </summary>
/// <typeparam name="TDbContext">
/// The type of the database context being managed. This must derive from DbContext.
/// </typeparam>
public class BaseUnitOfWork<TDbContext>(TDbContext dbContext) : IBaseUnitOfWork where TDbContext : DbContext
{
    /// <summary>
    /// Releases the resources used by the underlying database context.
    /// </summary>
    /// <remarks>
    /// This method disposes the database context, ensuring that any allocated
    /// resources, such as database connections, are properly released.
    /// </remarks>
    public virtual void Dispose()
    {
        dbContext.Dispose();
    }

    /// <summary>
    /// Disposes of the resources used by the current instance of the database context asynchronously.
    /// This method ensures that any resources held by the database context, such as connections
    /// to the database, are released asynchronously.
    /// </summary>
    /// <returns>
    /// A ValueTask that represents the asynchronous dispose operation.
    /// </returns>
    public virtual ValueTask DisposeAsync()
    {
        return dbContext.DisposeAsync();
    }

    /// <summary>
    /// Saves all changes made in the underlying data context to the database.
    /// </summary>
    /// <remarks>
    /// This method persists changes synchronously by invoking the underlying data context's SaveChanges method.
    /// It blocks the calling thread until the operation completes.
    /// </remarks>
    public void SaveChanges()
    {
        dbContext.SaveChanges();
    }

    /// <summary>
    /// Saves all changes made in the context to the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">
    /// A token to monitor for cancellation requests. The default value is CancellationToken.None.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous save operation, containing the number of state entries written to the database.
    /// </returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}