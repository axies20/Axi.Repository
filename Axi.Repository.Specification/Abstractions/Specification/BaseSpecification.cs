using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Represents a base class for constructing query specifications in a repository pattern.
/// Provides a mechanism to define query criteria, include paths, ordering, and query behaviors.
/// </summary>
/// <typeparam name="T">Type of the entity for which the specification is created.</typeparam>
public abstract partial class BaseSpecification<T> : ISpecification<T> where T : class
{
    /// <summary>
    /// A private field that stores a collection of include paths used in entity specifications for query composition.
    /// These include paths specify related entities to include in the query results, enabling eager loading of
    /// associated data.
    /// </summary>
    private readonly List<string> _includePaths = [];

    /// <summary>
    /// Gets the expression that defines the criteria used to filter entities
    /// in a specification. The criteria is represented as a lambda expression
    /// which defines the conditions that entities must satisfy to be
    /// included in the results.
    /// </summary>
    /// <remarks>
    /// If no criteria have been specified, this property returns null.
    /// The criteria can be defined using methods such as Where, OrWhere,
    /// WhereIf, and OrWhereIf in derived classes to build complex query
    /// conditions.
    /// This property is read-only and dynamically constructed using the
    /// internal <c>BuildCriteria</c> method.
    /// </remarks>
    public Expression<Func<T, bool>>? Criteria => BuildCriteria();

    /// <summary>
    /// Represents a collection of navigation property paths to include when constructing a query.
    /// These paths determine which related entities should be eagerly loaded as part of the query result set.
    /// </summary>
    public IReadOnlyList<string> IncludePaths => _includePaths;

    /// <summary>
    /// Represents a LINQ expression used to define the property or field by which the elements
    /// in the sequence should be ordered in ascending order.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the entity being queried.
    /// </typeparam>
    /// <remarks>
    /// Assigning an expression to this property enables ordering of results in an ascending manner.
    /// This property is typically set using the <c>ApplyOrderBy</c> method within the extending class.
    /// Only one ordering criteria can be applied at a time.
    /// </remarks>
    public Expression<Func<T, object>>? OrderBy { get; private set; }

    /// <summary>
    /// Gets a lambda expression that defines the descending order criteria to be applied in a query.
    /// </summary>
    /// <remarks>
    /// This property is used to specify a sorting order based on a field or property in the descending direction.
    /// It evaluates to an expression that determines how the data should be ordered.
    /// If not set, no descending sorting will be applied.
    /// </remarks>
    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    /// <summary>
    /// Indicates whether the query should use split queries for related data loading.
    /// Split queries load the primary data and related data in separate queries,
    /// reducing the risk of creating overly complex or large single queries,
    /// which can sometimes result in performance issues or SQL limitations.
    /// </summary>
    public bool AsSplitQuery { get; private set; }

    /// <summary>
    /// Determines whether the specification should configure the query to be a no-tracking query.
    /// When set to true, Entity Framework will not track changes for the entities returned by the query.
    /// This is typically used to improve performance when query results do not need to be updated, or when
    /// the entities are not intended to be persisted back to the database context.
    /// </summary>
    public bool AsNoTracking { get; private set; }

    /// <summary>
    /// Constructs and returns an expression used to define the criteria for filtering entities
    /// of type <typeparamref name="T"/>. This method is intended to be overridden or utilized
    /// internally by the specification to build complex predicate logic.
    /// </summary>
    /// <returns>
    /// An expression representing the filtering criteria for the specification, or null
    /// if no criteria have been defined.
    /// </returns>
    private partial Expression<Func<T, bool>>? BuildCriteria();

    /// Sets the "OrderBy" expression for sorting entities in ascending order within the specification.
    /// <param name="orderByExpression">
    /// An expression that specifies the property by which the entities will be ordered in ascending order.
    /// The expression should point to a single property of the entity type.
    /// </param>
    protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;

    /// Applies the given order-by-descending expression to the specification.
    /// <param name="orderByDescExpression">
    /// The expression specifying the property to use for descending ordering.
    /// </param>
    protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescExpression) =>
        OrderByDescending = orderByDescExpression;

    /// <summary>
    /// Enables the split query feature for the specification, which allows splitting a query
    /// with multiple includes into multiple SQL statements. This can improve performance
    /// in scenarios where a single joined query may load excessive amounts of data or
    /// where query complexity may degrade performance in the database.
    /// </summary>
    protected void EnableSplitQuery() => AsSplitQuery = true;

    /// Enables the no-tracking behavior for the query represented by the specification.
    /// When no-tracking is enabled, the query results will not be tracked by the underlying
    /// Entity Framework context. This is useful for read-only queries where changes to
    /// the retrieved entities are not required to be monitored by the context.
    /// This method modifies the `AsNoTracking` property of the specification to `true`.
    /// Use this feature to improve performance when tracking is unnecessary, such as
    /// when working with entities that will not be modified or saved back to the database.
    protected void EnableNoTracking() => AsNoTracking = true;
}