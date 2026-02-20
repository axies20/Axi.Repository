using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Represents an evaluator that applies "No Tracking" behavior to a query
/// if the corresponding <see cref="ISpecification{T}.AsNoTracking"/> property is set to true.
/// This evaluator ensures that Entity Framework does not track the entities during the query execution.
/// </summary>
internal sealed class NoTrackingEvaluator : IEvaluator
{
    /// <summary>
    /// Represents an evaluator that applies no-tracking query behavior to an <see cref="IQueryable{T}"/>
    /// when the specification indicates that no-tracking mode is enabled.
    /// </summary>
    /// <remarks>
    /// No-tracking mode is typically used to query entities in a read-only manner, reducing
    /// the overhead of change tracking in the underlying database context. This evaluator is
    /// implemented as a singleton to ensure reusability and avoid redundant instantiations.
    /// </remarks>
    private NoTrackingEvaluator()
    {
    }

    /// <summary>
    /// Represents a singleton instance of the <see cref="NoTrackingEvaluator"/> class.
    /// This instance is used to apply the "no tracking" behavior in queries by utilizing
    /// the <see cref="DbContext.AsNoTracking"/> method when the corresponding specification
    /// indicates the need for it.
    /// </summary>
    public static NoTrackingEvaluator Instance { get; } = new();

    /// <summary>
    /// Indicates whether the evaluator specifically targets the criteria clause
    /// of a specification.
    /// </summary>
    /// <remarks>
    /// If <c>true</c>, the evaluator is responsible for processing the criteria
    /// defined in a specification as part of the query transformation.
    /// If <c>false</c>, the evaluator does not handle criteria processing.
    /// </remarks>
    public bool IsCriteriaEvaluator => false;

    /// <summary>
    /// Modifies the provided query based on the specification's AsNoTracking setting.
    /// </summary>
    /// <typeparam name="T">The type of the entity being queried.</typeparam>
    /// <param name="query">The original query.</param>
    /// <param name="spec">The specification that may indicate whether the query should use AsNoTracking.</param>
    /// <returns>The modified query, with AsNoTracking applied if specified in the specification.</returns>
    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
        => spec.AsNoTracking ? query.AsNoTracking() : query;
}