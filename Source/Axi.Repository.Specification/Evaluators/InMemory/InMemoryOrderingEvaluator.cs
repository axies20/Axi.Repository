using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Evaluators.InMemory;

/// <summary>
/// Applies configured ordering to in-memory collections, preferring ascending ordering when both directions are configured.
/// </summary>
public sealed class InMemoryOrderingEvaluator : IInMemoryEvaluator
{
    private InMemoryOrderingEvaluator()
    {
    }

    /// <summary>
    /// Gets the shared stateless evaluator instance.
    /// </summary>
    public static InMemoryOrderingEvaluator Instance { get; } = new();

    /// <inheritdoc />
    public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec)
    {
        if (spec.OrderBy is not null)
            return query.OrderBy(spec.OrderBy.Compile());

        if (spec.OrderByDescending is not null)
            return query.OrderByDescending(spec.OrderByDescending.Compile());

        return query;
    }
}
