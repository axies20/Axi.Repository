using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Applies one part of a specification to an in-memory collection.
/// </summary>
public interface IInMemoryEvaluator
{
    /// <summary>
    /// Applies the evaluator's part of a specification to an in-memory collection.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="query">The source collection.</param>
    /// <param name="spec">The specification to apply.</param>
    /// <returns>The collection after this evaluator has applied its transformation.</returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec);
}
