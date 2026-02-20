namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Represents a unit of work that manages transactional changes to the data context.
/// </summary>
public interface IBaseUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Synchronously saves all changes to the database.
    /// </summary>
    void SaveChanges();

    /// <summary>
    /// Asynchronously saves all changes to the database.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}