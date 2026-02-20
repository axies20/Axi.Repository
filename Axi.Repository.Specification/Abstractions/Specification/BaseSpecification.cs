using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Base class for building query specifications.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public abstract partial class BaseSpecification<T> : ISpecification<T> where T : class
{
    private readonly List<string> _includePaths = [];

    /// <summary>
    /// Filter criteria expression.
    /// </summary>
    public Expression<Func<T, bool>>? Criteria => BuildCriteria();

    /// <summary>
    /// Navigation paths for eager loading.
    /// </summary>
    public IReadOnlyList<string> IncludePaths => _includePaths;

    /// <summary>
    /// Ascending order expression.
    /// </summary>
    public Expression<Func<T, object>>? OrderBy { get; private set; }

    /// <summary>
    /// Descending order expression.
    /// </summary>
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    /// <summary>
    /// Enable split query behavior.
    /// </summary>
    public bool AsSplitQuery { get; private set; }

    /// <summary>
    /// Enable no-tracking behavior for read-only queries.
    /// </summary>
    public bool AsNoTracking { get; private set; }

    private partial Expression<Func<T, bool>>? BuildCriteria();

    /// <summary>
    /// Applies ascending order.
    /// </summary>
    /// <param name="orderByExpression">Order expression.</param>
    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;

    /// <summary>
    /// Applies descending order.
    /// </summary>
    /// <param name="orderByDescExpression">Order expression.</param>
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