using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Specification interface for query criteria, includes, ordering, and query behaviors.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Filter criteria expression.
    /// </summary>
    Expression<Func<T, bool>>? Criteria { get; }

    /// <summary>
    /// Navigation paths for eager loading.
    /// </summary>
    IReadOnlyList<string> IncludePaths { get; }

    /// <summary>
    /// Ascending order expression.
    /// </summary>
    Expression<Func<T, object>>? OrderBy { get; }

    /// <summary>
    /// Descending order expression.
    /// </summary>
    Expression<Func<T, object>>? OrderByDescending { get; }

    /// <summary>
    /// Enable split query behavior.
    /// </summary>
    bool AsSplitQuery { get; }

    /// <summary>
    /// Enable no-tracking behavior for read-only queries.
    /// </summary>
    bool AsNoTracking { get; }
}