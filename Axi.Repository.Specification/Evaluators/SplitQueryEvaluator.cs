using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// An evaluator responsible for transforming queryable data sources to utilize split queries
/// when certain conditions specified in the <see cref="ISpecification{T}"/> are met.
/// </summary>
/// <remarks>
/// This evaluator modifies the query by applying the <c>AsSplitQuery</c> method if the associated
/// specification supports split queries and contains include paths.
/// </remarks>
internal sealed class SplitQueryEvaluator : IEvaluator
{
    /// <summary>
    /// Represents an evaluator that applies split query behavior to an <see cref="IQueryable{T}"/>
    /// when a specification indicates the use of split queries and includes include paths.
    /// </summary>
    /// <remarks>
    /// Split queries are used to optimize performance by splitting a single SQL query with multiple
    /// joins into multiple queries, each retrieving data for a specific include path.
    /// This evaluator modifies the query based on the <see cref="ISpecification{T}"/> provided,
    /// applying the split query behavior only when the specification requires it.
    /// </remarks>
    private SplitQueryEvaluator()
    {
    }

    /// <summary>
    /// Gets the singleton instance of the <see cref="SplitQueryEvaluator"/> class.
    /// This property ensures that only one instance of the evaluator is created
    /// and reused throughout the application lifecycle.
    /// </summary>
    public static SplitQueryEvaluator Instance { get; } = new();

    /// <summary>
    /// Indicates whether the evaluator specifically targets the criteria clause of a specification.
    /// </summary>
    /// <remarks>
    /// If the property value is true, the evaluator processes the criteria section of the specification,
    /// typically by applying it as a LINQ Where clause to the provided <see cref="IQueryable{T}"/>.
    /// A value of false signifies that the evaluator does not process criteria directly but
    /// serves other purposes, such as handling includes, ordering, or query splitting.
    /// </remarks>
    public bool IsCriteriaEvaluator => false;

    /// <summary>
    /// Modifies the provided query based on the split query settings and inclusion paths defined in the specification.
    /// If the specification has <c>AsSplitQuery</c> set to true and include paths are specified, the query will be modified
    /// to execute as a split query.
    /// </summary>
    /// <typeparam name="T">The type of entity being queried.</typeparam>
    /// <param name="query">The original query to be modified.</param>
    /// <param name="spec">The specification containing the split query and inclusion path settings.</param>
    /// <returns>The modified query, potentially set up as a split query.</returns>
    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        if (spec is { AsSplitQuery: true, IncludePaths.Count: > 0 })
            query = query.AsSplitQuery();

        return query;
    }
}