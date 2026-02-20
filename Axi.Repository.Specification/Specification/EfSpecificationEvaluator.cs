using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Evaluators;

namespace Axi.Repository.Specification.Specification;

/// <summary>
/// A static helper class that provides methods to evaluate and apply specifications
/// on LINQ queries, often in the context of Entity Framework.
/// </summary>
/// <remarks>
/// This class is primarily used for filtering, sorting, and applying criteria to
/// IQueryable objects based on provided specifications.
/// It operates on queries of type <c>IQueryable&lt;T&gt;</c> where <c>T</c> is a class.
/// This class is stateless and thread-safe.
/// </remarks>
internal static class EfSpecificationEvaluator
{
    /// <summary>
    /// Represents a collection of <see cref="IEvaluator"/> instances used by the Entity Framework
    /// specification evaluation pipeline. These evaluators are applied to IQueryable
    /// objects to transform queries based on specified criteria, including filtering, sorting,
    /// including related entities, and configuring query behavior.
    /// </summary>
    private static readonly IEvaluator[] Evaluators =
    [
        CriteriaEvaluator.Instance,
        IncludePathsEvaluator.Instance,
        NoTrackingEvaluator.Instance,
        SplitQueryEvaluator.Instance,
        OrderingEvaluator.Instance
    ];

    /// <summary>
    /// Applies a specification to the given queryable sequence, modifying it based on the provided specification's criteria,
    /// include paths, ordering, and other configuration elements.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the queryable sequence.</typeparam>
    /// <param name="query">The initial queryable sequence to which the specification will be applied.</param>
    /// <param name="spec">The specification containing the criteria, include paths, and additional query configuration.
    /// If null, the original queryable sequence is returned unmodified.</param>
    /// <returns>A new queryable sequence modified according to the provided specification.
    /// Returns the original queryable sequence if the specification is null.</returns>
    public static IQueryable<T> Apply<T>(IQueryable<T> query, ISpecification<T>? spec) where T : class
    {
        if (spec is null) return query;

        foreach (var e in Evaluators)
            query = e.GetQuery(query, spec);

        return query;
    }

    /// <summary>
    /// Applies only the criteria-related evaluators from the specification to an <see cref="IQueryable{T}"/> query.
    /// </summary>
    /// <typeparam name="T">The type of the entity being queried.</typeparam>
    /// <param name="query">The initial queryable source to which criteria will be applied.</param>
    /// <param name="spec">The specification containing the criteria to apply. Can be null.</param>
    /// <returns>
    /// A new <see cref="IQueryable{T}"/> instance with the applied criteria from the specification.
    /// If no criteria are provided or the specification is null, the original query is returned.
    /// </returns>
    public static IQueryable<T> ApplyCriteriaOnly<T>(IQueryable<T> query, ISpecification<T>? spec) where T : class
    {
        if (spec is null) return query;

        foreach (var e in Evaluators)
            if (e.IsCriteriaEvaluator)
                query = e.GetQuery(query, spec);

        return query;
    }
}