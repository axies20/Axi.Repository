namespace Axi.Repository.Abstractions.Repository;

/// <summary>
/// Defines operations that stage entity additions, modifications, and removals.
/// </summary>
/// <typeparam name="T">The type of the entity managed by the repository.</typeparam>
/// <remarks>
/// These operations do not persist changes. Persist the staged changes through the associated
/// <see cref="IUnitOfWork"/>.
/// </remarks>
public interface IWriteRepository<in T> where T : class
{
    /// <summary>
    /// Stages a single entity for insertion.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    void Add(T entity);

    /// <summary>
    /// Asynchronously stages an entity for insertion.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Asynchronously stages a collection of entities for insertion.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    /// <summary>
    /// Stages a collection of entities for insertion.
    /// </summary>
    /// <param name="entities">The collection of entities to add.</param>
    void AddRange(IEnumerable<T> entities);

    /// <summary>
    /// Stages the specified entity for update.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(T entity);

    /// <summary>
    /// Stages a collection of entities for update.
    /// </summary>
    /// <param name="entities">The collection of entities to update.</param>
    void UpdateRange(IEnumerable<T> entities);

    /// <summary>
    /// Stages the specified entity for deletion.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    void Delete(T entity);

    /// <summary>
    /// Stages a collection of entities for deletion.
    /// </summary>
    /// <param name="entities">The collection of entities to remove.</param>
    void DeleteRange(IEnumerable<T> entities);
}
