using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Applies no-tracking behavior to queries.
/// </summary>
internal sealed class NoTrackingEvaluator : IEvaluator
{
    private NoTrackingEvaluator()
    {
    }

    public static NoTrackingEvaluator Instance { get; } = new();

    public bool IsCriteriaEvaluator => false;

    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
        => spec.AsNoTracking ? query.AsNoTracking() : query;
}