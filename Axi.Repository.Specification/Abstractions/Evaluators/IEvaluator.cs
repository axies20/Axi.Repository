using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Represents an interface for defining query evaluators that are used to process
/// and transform <see cref="IQueryable{T}"/> objects based on a given specification.
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// Indicates whether the evaluator is responsible for processing criteria.
    /// When set to <c>true</c>, the evaluator applies filtering logic based on specified criteria
    /// in the <see cref="ISpecification{T}"/>. Otherwise, it performs other types of operations
    /// such as ordering, including navigation properties, or enabling/disabling query tracking.
    /// </summary>
    bool IsCriteriaEvaluator { get; }

    /// <summary>
    /// Modifies the provided <see cref="IQueryable{T}"/> based on the criteria and configuration
    /// specified in the given <see cref="ISpecification{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the <see cref="IQueryable{T}"/>.</typeparam>
    /// <param name="query">The base query to be modified.</param>
    /// <param name="spec">The specification containing criteria and configuration for modifying the query.</param>
    /// <returns>A modified <see cref="IQueryable{T}"/> reflecting the specification's criteria and configuration.</returns>
    IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class;
}