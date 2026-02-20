using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using LinqKit;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Represents an evaluator that processes <see cref="IQueryable{T}"/> objects
/// based on the criteria specified in a <see cref="ISpecification{T}"/>.
/// </summary>
/// <remarks>
/// This evaluator specifically targets the criteria clause of the specification.
/// If the criteria is null, the query remains unchanged. Otherwise, it applies the
/// criteria as a LINQ Where clause to the provided query.
/// </remarks>
internal sealed class CriteriaEvaluator : IEvaluator
{
    /// <summary>
    /// Represents a query evaluator that processes and transforms an <see cref="IQueryable{T}"/>
    /// based on the filtering criteria defined in an <see cref="ISpecification{T}"/>.
    /// </summary>
    /// <remarks>
    /// The <see cref="CriteriaEvaluator"/> is responsible for applying the filtering
    /// logic defined in the <see cref="ISpecification{T}.Criteria"/> property to the query.
    /// If no criteria are specified, the query is returned unchanged.
    /// This evaluator supports the use of LINQKit's <see cref="LinqKit.Extensions.AsExpandableEFCore"/>
    /// for handling predicate expansion in Entity Framework Core queries.
    /// </remarks>
    private CriteriaEvaluator()
    {
    }

    /// <summary>
    /// Represents the singleton instance of the <see cref="CriteriaEvaluator"/> class.
    /// This instance is used to access the functionality of the CriteriaEvaluator,
    /// which applies criteria-based filtering logic to a query.
    /// </summary>
    public static CriteriaEvaluator Instance { get; } = new();

    /// <summary>
    /// Gets a value indicating whether the current evaluator is a criteria evaluator.
    /// A criteria evaluator applies filtering logic to the query using specified criteria.
    /// </summary>
    public bool IsCriteriaEvaluator => true;

    /// <summary>
    /// Applies the specified criteria from the provided specification to the given query.
    /// </summary>
    /// <typeparam name="T">The type of the entities in the query.</typeparam>
    /// <param name="query">The source query to which the criteria should be applied.</param>
    /// <param name="spec">The specification containing the criteria to filter the query.</param>
    /// <returns>A new query filtered by the criteria in the specification. If no criteria are specified, the original query is returned.</returns>
    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        if (spec.Criteria is null)
            return query;
        return query.AsExpandableEFCore().Where(spec.Criteria);
    }
}