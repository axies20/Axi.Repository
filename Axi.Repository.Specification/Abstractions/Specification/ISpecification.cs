using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Defines an interface for specifying query criteria, include paths, ordering,
/// and additional query behavior for data access.
/// </summary>
/// <typeparam name="T">The type of the entity for which the specification is defined.</typeparam>
/// <remarks>
/// The <see cref="ISpecification{T}"/> interface is commonly used in the context of
/// the repository pattern to define reusable, composable, and testable query logic.
/// It allows consumers to specify filtering criteria, include paths for eager loading,
/// ordering options, and query execution strategies such as no-tracking or split queries.
/// </remarks>
public interface ISpecification<T>
{
    /// <summary>
    /// Gets the expression that defines the filter criteria for the query.
    /// This allows specifying a condition to fetch only the entities
    /// that satisfy the given predicate.
    /// </summary>
    /// <remarks>
    /// Used in query construction within the repository to restrict the
    /// data fetched from the data source based on the provided condition.
    /// Can be null if no criteria are specified.
    /// </remarks>
    Expression<Func<T, bool>>? Criteria { get; }

    /// <summary>
    /// Gets a collection of navigation property paths that should be included
    /// in the query to enable eager loading of related entities.
    /// </summary>
    /// <remarks>
    /// This property is typically used in the repository pattern to specify which related data
    /// should be included as part of the query results. It allows loading of related entities
    /// to avoid lazy-loading and reduce the number of database round-trips.
    /// </remarks>
    IReadOnlyList<string> IncludePaths { get; }

    /// <summary>
    /// Specifies an expression used for ordering query results in ascending order.
    /// Can be applied to a repository query to dictate the sorting behavior for
    /// the data retrieval process.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the entity for which the ordering is defined.
    /// </typeparam>
    /// <remarks>
    /// If both OrderBy and OrderByDescending are specified, only the last one applied
    /// will take precedence. This property is typically set using the
    /// <c>ApplyOrderBy</c> method in a derived specification class.
    /// </remarks>
    Expression<Func<T, object>>? OrderBy { get; }

    /// <summary>
    /// Specifies an expression used for ordering query results in descending order.
    /// </summary>
    /// <typeparam name="T">The type of the entity being queried.</typeparam>
    /// <remarks>
    /// This property defines a lambda expression that determines the descending sort order
    /// based on a specific property or calculated value of the entity. If specified,
    /// this will override any previously defined ascending order rules by prioritizing this descending order.
    /// </remarks>
    Expression<Func<T, object>>? OrderByDescending { get; }

    /// <summary>
    /// Indicates whether the split query behavior should be applied to the specification.
    /// When set to true, the query results will be loaded using multiple database queries for related collections,
    /// reducing the risk of the Cartesian explosion problem in scenarios with complex relationships.
    /// This property is useful for improving performance or avoiding excessive data retrieval in certain queries.
    /// </summary>
    bool AsSplitQuery { get; }

    /// <summary>
    /// Indicates whether queries generated from the specification should be executed without
    /// entity tracking in the persistence context. Enabling this option is suitable for
    /// scenarios where entities are intended to be read-only and not modified or tracked by
    /// the context.
    /// </summary>
    /// <remarks>
    /// This property is typically used to optimize read-only queries by disabling change
    /// tracking, thereby reducing memory usage and processing overhead. When enabled,
    /// any entities retrieved using this specification will not be tracked by the persistence
    /// context, meaning changes to these entities are not automatically persisted.
    /// </remarks>
    bool AsNoTracking { get; }
}