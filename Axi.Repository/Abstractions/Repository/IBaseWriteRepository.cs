namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Provides write operations for a repository managing entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the entity managed by the repository.</typeparam>
public interface IBaseWriteRepository<in T> where T : class
{
    /// <summary>
    /// Adds a single entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(T entity);

    /// <summary>
    /// Adds an entity to the data store asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add to the data store.</param>
    /// <param name="ct">The cancellation token to monitor for request cancellation.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(T entity, CancellationToken ct);

    /// <summary>
    /// Asynchronously adds a collection of entities to the repository.
    /// </summary>
    /// <param name="entities">
    /// The collection of entities to be added to the repository.
    /// </param>
    /// <param name="ct">
    /// A cancellation token to monitor for request cancellation.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation of adding the collection of entities.
    /// </returns>
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken ct);

    /// <summary>
    /// Adds a collection of entities to the repository.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    void AddRange(IEnumerable<T> entities);

    /// <summary>
    /// Updates the specified entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to be updated. Must be an instance of a class.</param>
    void Update(T entity);

    /// <summary>
    /// Updates a collection of entities in the repository.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    void UpdateRange(IEnumerable<T> entities);

    /// <summary>
    /// Removes the specified entity from the data store.
    /// The changes are not persisted to the database until the save operation is performed.
    /// </summary>
    /// <param name="entity">The entity to be removed from the data store.</param>
    void Delete(T entity);
}