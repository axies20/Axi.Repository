using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Applies include paths for eager loading.
/// </summary>
internal sealed class IncludePathsEvaluator : IEvaluator
{
    private IncludePathsEvaluator()
    {
    }

    public static IncludePathsEvaluator Instance { get; } = new();

    public bool IsCriteriaEvaluator => false;

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        foreach (var path in spec.IncludePaths)
            query = query.Include(path);

        return query;
    }
}