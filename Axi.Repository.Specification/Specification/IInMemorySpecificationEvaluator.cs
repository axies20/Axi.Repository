using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Evaluators.InMemory;

namespace Axi.Repository.Specification.Specification;

/// <summary>
/// Provides functionality to evaluate and filter in-memory collections
/// of entities using a collection of evaluators that apply specifications.
/// </summary>
/// <remarks>
/// The <see cref="InMemorySpecificationEvaluator"/> class iteratively applies specifications,
/// which can include filtering, ordering, and other behaviors, to in-memory collections.
/// It leverages a set of predefined <see cref="IInMemoryEvaluator"/> implementations
/// to process the specifications on the source data.
/// </remarks>
public class InMemorySpecificationEvaluator : IInMemorySpecificationEvaluator
{
    /// <summary>
    /// A collection of in-memory evaluators implementing <see cref="IInMemoryEvaluator"/>
    /// used to apply various specification-based transformations
    /// on an <see cref="IEnumerable{T}"/> data source. Each evaluator
    /// modifies the query based on a specific aspect of the provided
    /// specification, such as criteria or ordering.
    /// </summary>
    private readonly IInMemoryEvaluator[] _evaluators =
    [
        InMemoryCriteriaEvaluator.Instance,
        InMemoryOrderingEvaluator.Instance,
    ];

    /// <summary>
    /// Evaluates a collection of entities against a specified set of criteria, ordering, and query behaviors.
    /// </summary>
    /// <typeparam name="T">The type of the entities in the collection.</typeparam>
    /// <param name="source">The collection of entities to evaluate.</param>
    /// <param name="spec">The specification containing filtering, ordering, and additional query conditions.</param>
    /// <returns>A collection of entities that match the criteria specified in the <paramref name="spec"/>.</returns>
    public IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> spec)
    {
        var query = source;

        foreach (var e in _evaluators)
            query = e.Evaluate(query, spec);

        return query;
    }
}