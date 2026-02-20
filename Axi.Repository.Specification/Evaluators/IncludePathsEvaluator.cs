using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Evaluators;

/// <summary>
/// Represents an evaluator responsible for handling include paths in queryable objects.
/// This evaluator processes the <c>IncludePaths</c> property of an <see cref="ISpecification{T}"/>
/// to add the necessary include paths to the query using Entity Framework's <c>Include</c> method.
/// </summary>
internal sealed class IncludePathsEvaluator : IEvaluator
{
    /// <summary>
    /// Represents an evaluator that applies include paths specified in an <see cref="ISpecification{T}"/>
    /// to an <see cref="IQueryable{T}"/> for enabling eager loading of related entities.
    /// </summary>
    /// <remarks>
    /// The <see cref="IncludePathsEvaluator"/> processes the include paths defined in the
    /// <c>IncludePaths</c> property of the specification and applies them to the query
    /// via Entity Framework's <c>Include</c> method.
    /// </remarks>
    private IncludePathsEvaluator()
    {
    }

    /// <summary>
    /// Provides a globally accessible singleton instance of the <see cref="IncludePathsEvaluator"/> class.
    /// This instance is used to include navigation properties in a query based on the provided specification's include paths.
    /// </summary>
    public static IncludePathsEvaluator Instance { get; } = new();

    /// <summary>
    /// Indicates whether the evaluator is responsible for processing criteria clauses
    /// within a specification.
    /// </summary>
    /// <remarks>
    /// A value of <c>true</c> means the evaluator applies criteria-based filtering,
    /// typically using a LINQ Where clause. A value of <c>false</c> means the evaluator
    /// does not handle criteria processing.
    /// </remarks>
    public bool IsCriteriaEvaluator => false;

    /// <summary>
    /// Modifies the provided query by applying include paths specified in the given specification.
    /// </summary>
    /// <typeparam name="T">The type of the entity being queried.</typeparam>
    /// <param name="query">The initial query to be modified.</param>
    /// <param name="spec">The specification containing the list of include paths to apply to the query.</param>
    /// <returns>The modified query with the include paths applied.</returns>
    public IQueryable<T> GetQuery<T>(IQueryable<T> query, ISpecification<T> spec) where T : class
    {
        foreach (var path in spec.IncludePaths)
            query = query.Include(path);

        return query;
    }
}