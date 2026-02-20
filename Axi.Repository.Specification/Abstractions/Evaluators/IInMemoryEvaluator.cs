using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Represents an evaluator for applying in-memory query logic to a dataset based on a given specification.
/// </summary>
/// <remarks>
/// The <see cref="IInMemoryEvaluator"/> interface defines a contract for evaluating and transforming
/// in-memory collections using specification logic such as filtering, ordering, and other query behaviors.
/// Implementations of this interface are designed to work with the repository pattern, enabling
/// efficient and well-structured query logic that operates on in-memory data structures.
/// </remarks>
public interface IInMemoryEvaluator
{
    /// <summary>
    /// Evaluates a given collection of entities in-memory based on the specified criteria,
    /// include paths, and ordering defined in the provided specification.
    /// </summary>
    /// <typeparam name="T">The type of the entity to be evaluated.</typeparam>
    /// <param name="query">The collection of entities to evaluate.</param>
    /// <param name="spec">The specification that defines the evaluation criteria,
    /// include paths, ordering, and additional query behavior.</param>
    /// <returns>A collection of entities that match the criteria, include paths, and
    /// ordering specified in the given specification.</returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec);
}