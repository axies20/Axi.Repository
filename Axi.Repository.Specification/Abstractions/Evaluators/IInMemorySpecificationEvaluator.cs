using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Evaluates in-memory collections using specifications.
/// </summary>
public interface IInMemorySpecificationEvaluator
{
    /// <summary>
    /// Applies specification to a source collection.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="source">Source collection.</param>
    /// <param name="spec">Specification to apply.</param>
    /// <returns>Filtered and ordered collection.</returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> spec);
}