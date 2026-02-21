using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Applies ordering to queries.
/// </summary>
internal sealed class OrderingEvaluator : IEvaluator
{
    private OrderingEvaluator()
    {
    }

    public static OrderingEvaluator Instance { get; } = new();

    public bool IsCriteriaEvaluator => false;

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        if (spec.OrderBy is not null)
            return query.OrderBy(spec.OrderBy);

        if (spec.OrderByDescending is not null)
            return query.OrderByDescending(spec.OrderByDescending);

        return query;
    }
}