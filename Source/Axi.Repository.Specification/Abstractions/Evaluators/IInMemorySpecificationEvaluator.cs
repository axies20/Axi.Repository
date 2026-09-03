using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Evaluates in-memory collections using specifications.
/// </summary>
public interface IInMemorySpecificationEvaluator
{
    /// <summary>
    /// Applies all supported operations from a specification to a source collection.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="source">The source collection.</param>
    /// <param name="spec">The specification to apply.</param>
    /// <returns>The collection after all supported specification operations have been applied.</returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> spec);
}
