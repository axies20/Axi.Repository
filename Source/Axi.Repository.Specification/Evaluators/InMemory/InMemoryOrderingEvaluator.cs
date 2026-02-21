using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Evaluators.InMemory;

/// <summary>
/// Applies ordering to in-memory collections.
/// </summary>
public sealed class InMemoryOrderingEvaluator : IInMemoryEvaluator
{
    private InMemoryOrderingEvaluator()
    {
    }

    public static InMemoryOrderingEvaluator Instance { get; } = new();

    public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec)
    {
        if (spec.OrderBy is not null)
            return query.OrderBy(spec.OrderBy.Compile());

        if (spec.OrderByDescending is not null)
            return query.OrderByDescending(spec.OrderByDescending.Compile());

        return query;
    }
}