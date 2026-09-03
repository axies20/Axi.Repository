using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Applies one part of a specification to a query.
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// Gets whether this evaluator participates in criteria-only evaluation.
    /// </summary>
    bool IsCriteriaEvaluator { get; }

    /// <summary>
    /// Applies the evaluator's part of a specification to a query.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="query">The source query.</param>
    /// <param name="spec">The specification to apply.</param>
    /// <returns>The query after the evaluator has applied its transformation.</returns>
    IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class;
}
