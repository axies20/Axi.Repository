using System.Linq.Expressions;
using LinqKit;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Base class for query specifications with criteria building support.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public abstract partial class BaseSpecification<T>
{
    private ExpressionStarter<T>? _criteria;

    private partial Expression<Func<T, bool>>? BuildCriteria() => _criteria;

    /// <summary>
    /// Adds AND condition to criteria.
    /// </summary>
    /// <param name="predicate">Filter condition.</param>
    protected virtual void Where(Expression<Func<T, bool>> predicate)
    {
        if (_criteria is not null)
            _criteria = _criteria.And(predicate);
        else
            _criteria = PredicateBuilder.New(predicate);
    }

    /// <summary>
    /// Adds OR condition to criteria.
    /// </summary>
    /// <param name="predicate">Filter condition.</param>
    protected virtual void OrWhere(Expression<Func<T, bool>> predicate)
    {
        if (_criteria is null)
            _criteria = PredicateBuilder.New(predicate);
        else
            _criteria = _criteria.Or(predicate);
    }

    /// <summary>
    /// Adds AND condition if condition is true.
    /// </summary>
    /// <param name="condition">Determines if predicate is applied.</param>
    /// <param name="predicate">Filter condition.</param>
    protected virtual void WhereIf(bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition) Where(predicate);
    }

    /// <summary>
    /// Adds OR condition if condition is true.
    /// </summary>
    /// <param name="condition">Determines if predicate is applied.</param>
    /// <param name="predicate">Filter condition.</param>
    protected virtual void OrWhereIf(bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition)
            OrWhere(predicate);
    }

    /// <summary>
    /// Adds filter criteria.
    /// </summary>
    /// <param name="criteria">Filter condition.</param>
    protected virtual void AddCriteria(Expression<Func<T, bool>> criteria) => Where(criteria);
}