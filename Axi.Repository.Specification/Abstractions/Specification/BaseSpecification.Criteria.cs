using System.Linq.Expressions;
using LinqKit;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Represents a base class for defining reusable query specifications in the repository pattern.
/// </summary>
/// <typeparam name="T">The entity type for which the specification is applicable.</typeparam>
/// <remarks>
/// This class provides features such as building query criteria, configuring include paths for eager loading,
/// specifying ordering, and enabling query behaviors like split-query and no-tracking.
/// </remarks>
public abstract partial class BaseSpecification<T>
{
    /// <summary>
    /// Represents a private field that holds the core filtering logic
    /// for constructing query criteria in a specification.
    /// Combines multiple predicates using logical operators (AND/OR).
    /// </summary>
    /// <typeparam name="T">The type of the entity the criteria applies to.</typeparam>
    /// <remarks>
    /// The criteria can be dynamically composed using methods such as <c>Where</c>,
    /// <c>OrWhere</c>, <c>WhereIf</c>, and <c>OrWhereIf</c>.
    /// It is built using <c>PredicateBuilder</c> from the LinqKit library.
    /// </remarks>
    private ExpressionStarter<T>? _criteria;

    /// <summary>
    /// Builds and returns the combined criteria expression that defines the filtering logic
    /// for the current specification.
    /// </summary>
    /// <returns>
    /// A lambda expression representing the criteria for the specification, or null if no criteria
    /// have been defined.
    /// </returns>
    private partial Expression<Func<T, bool>>? BuildCriteria() => _criteria;

    /// <summary>
    /// Adds a filtering condition to the current specification. If a criteria already exists,
    /// the provided predicate will be combined with it using a logical "AND" operation.
    /// Otherwise, the provided predicate becomes the initial criteria.
    /// </summary>
    /// <param name="predicate">The predicate expression representing the filtering condition
    /// to be added to the specification.</param>
    protected virtual void Where(Expression<Func<T, bool>> predicate)
    {
        if (_criteria is not null)
            _criteria = _criteria.And(predicate);
        else
            _criteria = PredicateBuilder.New(predicate);
    }

    /// <summary>
    /// Adds an OR condition to the current specification criteria.
    /// Combines the existing criteria with the provided predicate using a logical OR operation.
    /// </summary>
    /// <param name="predicate">
    /// An expression specifying the condition to add to the specification.
    /// The predicate is combined with the current criteria using a logical OR clause.
    /// </param>
    protected virtual void OrWhere(Expression<Func<T, bool>> predicate)
    {
        if (_criteria is null)
            _criteria = PredicateBuilder.New(predicate);
        else
            _criteria = _criteria.Or(predicate);
    }

    /// <summary>
    /// Applies a conditional predicate to the current specification's criteria if the specified condition is true.
    /// </summary>
    /// <typeparam name="T">The type of the entity for which the specification is being constructed.</typeparam>
    /// <param name="condition">A boolean value that determines whether the predicate should be applied.</param>
    /// <param name="predicate">
    /// An expression representing the condition to be applied to the criteria if the specified condition is true.
    /// </param>
    protected virtual void WhereIf(bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition) Where(predicate);
    }

    /// <summary>
    /// Adds a logical 'OR' condition to the criteria if the specified condition evaluates to true.
    /// This method modifies the existing criteria by appending the provided predicate using a logical 'OR' operator
    /// only when the condition is satisfied.
    /// </summary>
    /// <param name="condition">
    /// A boolean value that determines whether the predicate should be applied.
    /// If true, the predicate is added to the criteria using the 'OR' operator.
    /// If false, no changes are made to the criteria.
    /// </param>
    /// <param name="predicate">
    /// The predicate to be added to the criteria. Represents a condition to be evaluated
    /// against the entities in the query.
    /// </param>
    protected virtual void OrWhereIf(bool condition, Expression<Func<T, bool>> predicate)
    {
        if (condition)
            OrWhere(predicate);
    }

    /// <summary>
    /// Adds a criteria to the specification, which defines the conditions for filtering entities.
    /// Multiple criteria can be combined using logical AND operations.
    /// </summary>
    /// <param name="criteria">An expression defining the filter condition to apply to the entities.</param>
    protected virtual void AddCriteria(Expression<Func<T, bool>> criteria) => Where(criteria);
}