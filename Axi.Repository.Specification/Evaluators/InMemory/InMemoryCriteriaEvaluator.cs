using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Evaluators.InMemory;

/// <summary>
/// Applies filter criteria to in-memory collections.
/// </summary>
public sealed class InMemoryCriteriaEvaluator : IInMemoryEvaluator
{
    private InMemoryCriteriaEvaluator()
    {
    }

    public static InMemoryCriteriaEvaluator Instance { get; } = new();

    public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria is null)
            return query;

        var predicate = spec.Criteria.Compile();
        return query.Where(predicate);
    }
}