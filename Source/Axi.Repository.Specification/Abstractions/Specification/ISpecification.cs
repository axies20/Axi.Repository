using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Describes query criteria, include paths, ordering, and Entity Framework query behavior.
/// </summary>
/// <typeparam name="T">The entity type described by the specification.</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Gets the filter criteria expression, or <see langword="null"/> when no filter is defined.
    /// </summary>
    Expression<Func<T, bool>>? Criteria { get; }

    /// <summary>
    /// Gets the navigation paths to include for eager loading.
    /// </summary>
    IReadOnlyList<string> IncludePaths { get; }

    /// <summary>
    /// Gets the ascending ordering expression, or <see langword="null"/> when it is not configured.
    /// </summary>
    Expression<Func<T, object>>? OrderBy { get; }

    /// <summary>
    /// Gets the descending ordering expression, or <see langword="null"/> when it is not configured.
    /// </summary>
    /// <remarks>If both ordering expressions are configured, ascending ordering takes precedence.</remarks>
    Expression<Func<T, object>>? OrderByDescending { get; }

    /// <summary>
    /// Gets whether split-query behavior is requested when include paths are configured.
    /// </summary>
    bool AsSplitQuery { get; }

    /// <summary>
    /// Gets whether Entity Framework change tracking should be disabled.
    /// </summary>
    bool AsNoTracking { get; }
}
