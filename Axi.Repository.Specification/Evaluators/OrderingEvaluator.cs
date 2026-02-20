using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Represents an evaluator responsible for applying ordering rules to an <see cref="IQueryable{T}"/>
/// based on the order-by and order-by-descending expressions defined in the provided specification.
/// </summary>
internal sealed class OrderingEvaluator : IEvaluator
{
    /// <summary>
    /// Represents an evaluator for applying ordering clauses (OrderBy and OrderByDescending)
    /// to an <see cref="IQueryable{T}"/> based on the specified ordering properties
    /// within an <see cref="ISpecification{T}"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="OrderingEvaluator"/> evaluates and applies ordering expressions
    /// defined in <see cref="ISpecification{T}.OrderBy"/> and
    /// <see cref="ISpecification{T}.OrderByDescending"/> to the query.
    /// If neither is defined, the query remains unaltered. This evaluator is non-criteria
    /// based, as it exclusively focuses on ordering constraints.
    /// </remarks>
    private OrderingEvaluator()
    {
    }

    /// <summary>
    /// Gets the singleton instance of the OrderingEvaluator.
    /// This property provides access to the single, shared instance of the
    /// OrderingEvaluator class. It ensures that the same instance is reused
    /// throughout the application, following the Singleton design pattern.
    /// </summary>
    public static OrderingEvaluator Instance { get; } = new();

    /// <summary>
    /// Indicates whether the evaluator is responsible for processing criteria-related specifications
    /// in the query evaluation process.
    /// </summary>
    /// <remarks>
    /// This property returns a boolean value that determines if the current evaluator specifically
    /// handles filtering criteria. For example, it may return true for evaluators that process
    /// criteria or conditions specified in a query, and false for evaluators that handle other
    /// aspects such as ordering or no-tracking behavior.
    /// </remarks>
    public bool IsCriteriaEvaluator => false;

    /// <summary>
    /// Modifies the given query by applying ordering rules based on the provided specification.
    /// </summary>
    /// <typeparam name="T">The type of the entity being queried.</typeparam>
    /// <param name="query">The base query to which the ordering rules will be applied.</param>
    /// <param name="spec">The specification containing the ordering expressions.</param>
    /// <returns>A modified query with the applied ordering rules or the original query if no ordering is defined.</returns>
    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        if (spec.OrderBy is not null)
            return query.OrderBy(spec.OrderBy);

        if (spec.OrderByDescending is not null)
            return query.OrderByDescending(spec.OrderByDescending);

        return query;
    }
}