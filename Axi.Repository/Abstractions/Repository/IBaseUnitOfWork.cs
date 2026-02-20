namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Represents the contract for a unit of work that manages changes applied
/// to the underlying data context. It ensures changes are saved or discarded
/// as a single transaction.
/// </summary>
public interface IBaseUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Saves all changes made in the underlying data context to the database.
    /// </summary>
    /// <remarks>
    /// This method persists changes synchronously, blocking the calling thread until the operation completes.
    /// </remarks>
    void SaveChanges();

    /// <summary>
    /// Saves all changes made in the context to the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">
    /// A CancellationToken to observe while waiting for the task to complete.
    /// The default value is CancellationToken.None.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous save operation.
    /// The task result contains the number of state entries written to the database.
    /// </returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}