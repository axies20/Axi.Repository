using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Base class for building query specifications.
/// </summary>
/// <typeparam name="T">The entity type described by the specification.</typeparam>
public abstract partial class BaseSpecification<T> : ISpecification<T> where T : class
{
    private readonly List<string> _includePaths = [];

    /// <summary>
    /// Gets the filter criteria expression, or <see langword="null"/> when no filter is defined.
    /// </summary>
    public Expression<Func<T, bool>>? Criteria => BuildCriteria();

    /// <summary>
    /// Gets the navigation paths to include for eager loading.
    /// </summary>
    public IReadOnlyList<string> IncludePaths => _includePaths;

    /// <summary>
    /// Gets the ascending ordering expression, or <see langword="null"/> when it is not configured.
    /// </summary>
    public Expression<Func<T, object>>? OrderBy { get; private set; }

    /// <summary>
    /// Gets the descending ordering expression, or <see langword="null"/> when it is not configured.
    /// </summary>
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    /// <summary>
    /// Gets whether split-query behavior is requested when include paths are configured.
    /// </summary>
    public bool AsSplitQuery { get; private set; }

    /// <summary>
    /// Gets whether Entity Framework change tracking should be disabled.
    /// </summary>
    public bool AsNoTracking { get; private set; }

    private partial Expression<Func<T, bool>>? BuildCriteria();

    /// <summary>
    /// Configures ascending ordering.
    /// </summary>
    /// <param name="orderByExpression">Order expression.</param>
    /// <remarks>
    /// If both ordering directions are configured, ascending ordering takes precedence.
    /// </remarks>
    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;

    /// <summary>
    /// Configures descending ordering.
    /// </summary>
    /// <param name="orderByDescExpression">Order expression.</param>
    /// <remarks>
    /// If both ordering directions are configured, ascending ordering takes precedence.
    /// </remarks>
    protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression) =>
        OrderByDescending = orderByDescExpression;

    /// <summary>
    /// Enables split query behavior.
    /// </summary>
    protected void EnableSplitQuery() => AsSplitQuery = true;

    /// <summary>
    /// Enables no-tracking behavior.
    /// </summary>
    protected void EnableNoTracking() => AsNoTracking = true;
}
