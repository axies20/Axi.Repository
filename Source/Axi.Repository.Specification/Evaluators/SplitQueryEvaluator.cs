using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Applies split query behavior when includes are present.
/// </summary>
internal sealed class SplitQueryEvaluator : IEvaluator
{
    private SplitQueryEvaluator()
    {
    }

    public static SplitQueryEvaluator Instance { get; } = new();

    public bool IsCriteriaEvaluator => false;

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        if (spec is { AsSplitQuery: true, IncludePaths.Count: > 0 })
            query = query.AsSplitQuery();

        return query;
    }
}