using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Evaluators.InMemory;

namespace Axi.Repository.Specification.Specification;

/// <summary>
/// Applies a specification pipeline to in-memory collections.
/// </summary>
public class InMemorySpecificationEvaluator : IInMemorySpecificationEvaluator
{
    private readonly IInMemoryEvaluator[] _evaluators =
    [
        InMemoryCriteriaEvaluator.Instance,
        InMemoryOrderingEvaluator.Instance,
    ];

    /// <inheritdoc />
    public IEnumerable<T> Evaluate<T>(IEnumerable<T> source, ISpecification<T> spec)
    {
        var query = source;

        foreach (var e in _evaluators)
            query = e.Evaluate(query, spec);

        return query;
    }
}
