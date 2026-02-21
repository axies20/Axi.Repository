using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Evaluators;

namespace Axi.Repository.Specification.Specification;

/// <summary>
/// Applies specifications to Entity Framework queries.
/// </summary>
internal static class EfSpecificationEvaluator
{
    private static readonly IEvaluator[] Evaluators =
    [
        CriteriaEvaluator.Instance,
        IncludePathsEvaluator.Instance,
        NoTrackingEvaluator.Instance,
        SplitQueryEvaluator.Instance,
        OrderingEvaluator.Instance
    ];

    /// <summary>
    /// Applies specification to query.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="query">Source query.</param>
    /// <param name="spec">Specification to apply.</param>
    /// <returns>Modified query.</returns>
    public static IQueryable<T> Apply<T>(IQueryable<T> query, ISpecification<T>? spec) where T : class
    {
        if (spec is null) return query;

        foreach (var e in Evaluators)
            query = e.GetQuery(query, spec);

        return query;
    }

    /// <summary>
    /// Applies only filter criteria from specification.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    /// <param name="query">Source query.</param>
    /// <param name="spec">Specification to apply.</param>
    /// <returns>Query with criteria applied.</returns>
    public static IQueryable<T> ApplyCriteriaOnly<T>(IQueryable<T> query, ISpecification<T>? spec) where T : class
    {
        if (spec is null) return query;

        foreach (var e in Evaluators)
            if (e.IsCriteriaEvaluator)
                query = e.GetQuery(query, spec);

        return query;
    }
}