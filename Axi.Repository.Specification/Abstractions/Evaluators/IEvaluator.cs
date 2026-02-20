using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Query evaluator for applying specifications to IQueryable.
/// </summary>
public interface IEvaluator
{
    /// <summary>
    /// Indicates if evaluator processes filter criteria.
    /// </summary>
    bool IsCriteriaEvaluator { get; }

    /// <summary>
    /// Applies specification to query.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="query">Base query.</param>
    /// <param name="spec">Specification to apply.</param>
    /// <returns>Modified query.</returns>
    IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class;
}