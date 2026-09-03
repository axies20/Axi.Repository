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
    /// Applies all supported operations from a specification to a query.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="query">The source query.</param>
    /// <param name="spec">Specification to apply, or <see langword="null"/> to leave the query unchanged.</param>
    /// <returns>The query after all supported specification operations have been applied.</returns>
    public static IQueryable<T> Apply<T>(IQueryable<T> query, ISpecification<T>? spec) where T : class
    {
        if (spec is null) return query;

        foreach (var e in Evaluators)
            query = e.GetQuery(query, spec);

        return query;
    }

    /// <summary>
    /// Applies only filter criteria from a specification.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <param name="query">The source query.</param>
    /// <param name="spec">Specification to apply, or <see langword="null"/> to leave the query unchanged.</param>
    /// <returns>The query with the specification's filter criteria applied.</returns>
    public static IQueryable<T> ApplyCriteriaOnly<T>(IQueryable<T> query, ISpecification<T>? spec) where T : class
    {
        if (spec is null) return query;

        foreach (var e in Evaluators)
            if (e.IsCriteriaEvaluator)
                query = e.GetQuery(query, spec);

        return query;
    }
}
