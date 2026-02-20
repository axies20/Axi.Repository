using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Evaluators.InMemory;

/// <summary>
/// Provides functionality to evaluate in-memory datasets using specified filtering criteria.
/// </summary>
/// <remarks>
/// The <see cref="InMemoryCriteriaEvaluator"/> is responsible for applying filtering logic on in-memory collections
/// based on the criteria defined within an <see cref="ISpecification{T}"/>.
/// This class implements a singleton pattern for reuse and efficiency.
/// </remarks>
public sealed class InMemoryCriteriaEvaluator : IInMemoryEvaluator
{
    /// <summary>
    /// Represents an in-memory evaluator that applies criteria from a specification
    /// to filter and transform a collection.
    /// </summary>
    /// <remarks>
    /// This sealed class provides a concrete implementation of the <see cref="IInMemoryEvaluator"/> interface,
    /// allowing in-memory collections of type <typeparamref name="T"/> to be filtered based on criteria specified
    /// in an <see cref="ISpecification{T}"/>. It evaluates conditions using a predicate generated from the criteria.
    /// </remarks>
    private InMemoryCriteriaEvaluator()
    {
    }

    /// <summary>
    /// Provides a singleton instance of the <see cref="InMemoryCriteriaEvaluator"/> class.
    /// </summary>
    /// <remarks>
    /// This property grants access to a globally shared instance of <see cref="InMemoryCriteriaEvaluator"/>.
    /// It is intended to be used for evaluating in-memory query criteria based on a given specification.
    /// The singleton instance ensures that only one instance of the evaluator is created and reused
    /// throughout the application, promoting consistency and reducing memory overhead.
    /// </remarks>
    public static InMemoryCriteriaEvaluator Instance { get; } = new();

    /// <summary>
    /// Evaluates a given in-memory query based on the criteria defined in the provided specification.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the queryable data source.</typeparam>
    /// <param name="query">An <see cref="IEnumerable{T}"/> representing the in-memory data set to be filtered or processed.</param>
    /// <param name="spec">The specification defining the filtering criteria to apply to the query.</param>
    /// <returns>An <see cref="IEnumerable{T}"/> containing the elements of the input query that satisfy the criteria defined in the specification.</returns>
    public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria is null)
            return query;

        var predicate = spec.Criteria.Compile();
        return query.Where(predicate);
    }
}