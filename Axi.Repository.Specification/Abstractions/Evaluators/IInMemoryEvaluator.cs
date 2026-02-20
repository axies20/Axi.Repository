using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// In-memory query evaluator for applying specifications to collections.
/// </summary>
public interface IInMemoryEvaluator
{
    /// <summary>
    /// Applies specification to in-memory collection.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="query">Source collection.</param>
    /// <param name="spec">Specification to apply.</param>
    /// <returns>Filtered collection.</returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec);
}