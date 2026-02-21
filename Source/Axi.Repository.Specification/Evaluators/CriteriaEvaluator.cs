using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using LinqKit;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Applies filter criteria to queries.
/// </summary>
internal sealed class CriteriaEvaluator : IEvaluator
{
    private CriteriaEvaluator()
    {
    }

    public static CriteriaEvaluator Instance { get; } = new();

    public bool IsCriteriaEvaluator => true;

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        if (spec.Criteria is null)
            return query;
        return query.AsExpandableEFCore().Where(spec.Criteria);
    }
}