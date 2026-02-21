using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Evaluators.InMemory;

namespace Axi.Repository.Specification.Specification;

/// <summary>
/// Applies specifications to in-memory collections.
/// </summary>
public class InMemorySpecificationEvaluator : IInMemorySpecificationEvaluator
{
    private readonly IInMemoryEvaluator[] _evaluators =
    [
        InMemoryCriteriaEvaluator.Instance,
        InMemoryOrderingEvaluator.Instance,
    ];

    /// <summary>
    /// Applies specification to collection.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="source">Source collection.</param>
    /// <param name="spec">Specification to apply.</param>
    /// <returns>Filtered and ordered collection.</returns>
    public IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> spec)
    {
        var query = source;

        foreach (var e in _evaluators)
            query = e.Evaluate(query, spec);

        return query;
    }
}