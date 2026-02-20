using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Abstractions.Evaluators;

/// <summary>
/// Defines an interface for evaluating in-memory collections of entities
/// based on specified criteria, ordering, and query behaviors.
/// </summary>
/// <remarks>
/// The <see cref="IInMemorySpecificationEvaluator"/> interface is designed to apply
/// specifications to in-memory collections, enabling complex query logic that aligns
/// with the semantics of a data repository. It iteratively applies the components
/// of a specification to filter, order, and manipulate the data set.
/// </remarks>
public interface IInMemorySpecificationEvaluator
{
    /// <summary>
    /// Evaluates a given collection of entities against the specified in-memory specification,
    /// applying filtering, include paths, and ordering as defined by the specification.
    /// </summary>
    /// <typeparam name="T">The type of the entity to be evaluated against the specification.</typeparam>
    /// <param name="source">The source collection of entities to evaluate.</param>
    /// <param name="spec">The specification defining the filtering, inclusion, and ordering criteria.</param>
    /// <returns>
    /// An enumerable containing the entities from the source collection that satisfy the specification's criteria,
    /// with applied include paths and ordering.
    /// </returns>
    IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> spec);
}