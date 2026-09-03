namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Coordinates saving changes and releasing the underlying data context.
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Persists all tracked changes to the database.
    /// </summary>
    void SaveChanges();

    /// <summary>
    /// Asynchronously persists all tracked changes to the database.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
