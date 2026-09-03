using System.Linq.Expressions;
using LinqKit;

namespace Axi.Repository.Specification.Abstractions.Specification;

public abstract partial class BaseSpecification<T>
{
    private ExpressionStarter<T>? _criteria;

    private partial Expression<Func<T, bool>>? BuildCriteria() => _criteria;

    /// <summary>
    /// Combines a predicate with the current criteria using a logical AND operation.
    /// </summary>
    /// <param name="predicate">The predicate to add.</param>
    protected virtual void Where(Expression<Func<T, bool>> predicate)
    {
        if (_criteria is not null)
            _criteria = _criteria.And(predicate);
        else
            _criteria = PredicateBuilder.New(predicate);
    }

    /// <summary>
    /// Combines a predicate with the current criteria using a logical OR operation.
    /// </summary>
    /// <param name="predicate">The predicate to add.</param>
    protected virtual void OrWhere(Expression<Func<T, bool>> predicate)
    {
        if (_criteria is null)
            _criteria = PredicateBuilder.New(predicate);
        else
            _criteria = _criteria.Or(predicate);
    }

    /// <summary>
    /// Adds a predicate using a logical AND operation when the condition is <see langword="true"/>.
    /// </summary>
    /// <param name="condition">Whether to add the predicate.</param>
    /// <param name="predicate">The predicate to add.</param>
    protected virtual void WhereIf(bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition) Where(predicate);
    }

    /// <summary>
    /// Adds a predicate using a logical OR operation when the condition is <see langword="true"/>.
    /// </summary>
    /// <param name="condition">Whether to add the predicate.</param>
    /// <param name="predicate">The predicate to add.</param>
    protected virtual void OrWhereIf(bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition)
            OrWhere(predicate);
    }

    /// <summary>
    /// Adds a predicate to the current criteria using a logical AND operation.
    /// </summary>
    /// <param name="criteria">The predicate to add.</param>
    protected virtual void AddCriteria(Expression<Func<T, bool>> criteria) => Where(criteria);
}
