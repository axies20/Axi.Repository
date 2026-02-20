using Axi.Repository.Specification.Abstractions.Evaluators;
using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Evaluators.InMemory;

/// <summary>
/// A sealed class that applies ordering logic to an in-memory collection based on the specified query criteria.
/// </summary>
/// <remarks>
/// The <see cref="InMemoryOrderingEvaluator"/> is responsible for handling ordering operations such as
/// sorting data in ascending or descending order. It evaluates the provided in-memory collection using the properties
/// outlined in an <see cref="ISpecification{T}"/> instance.
/// This evaluator processes query transformations in-memory, making it suitable for scenarios where
/// data has already been fully loaded into memory.
/// </remarks>
/// <example>
/// This evaluator looks for properties such as <c>OrderBy</c> or <c>OrderByDescending</c> in the provided
/// specification and applies the associated logic to the collection. If no ordering logic is specified,
/// the input query remains unchanged.
/// </example>
public sealed class InMemoryOrderingEvaluator : IInMemoryEvaluator
{
    /// <summary>
    /// Provides an implementation of the <see cref="IInMemoryEvaluator"/> interface that handles
    /// ordering operations on in-memory collections based on the specified ordering criteria.
    /// </summary>
    /// <remarks>
    /// The <see cref="InMemoryOrderingEvaluator"/> is designed to evaluate ordering logic for in-memory
    /// datasets using the <see cref="ISpecification{T}"/> interface. This evaluator applies the
    /// `OrderBy` or `OrderByDescending` expressions defined in the specification to the provided collection.
    /// </remarks>
    private InMemoryOrderingEvaluator()
    {
    }

    /// <summary>
    /// Provides a singleton instance of the InMemoryOrderingEvaluator class for evaluating
    /// in-memory data queries with ordering capabilities.
    /// </summary>
    /// <remarks>
    /// The Instance property is used to access a single shared instance of the InMemoryOrderingEvaluator.
    /// This ensures that only one instance of the class is created and can be reused wherever needed in
    /// the application to evaluate queries with specified ordering criteria.
    /// Utilizes ordering expressions, such as OrderBy and OrderByDescending, to process the given query
    /// in accordance with the specifications provided.
    /// Thread-safety is ensured as the instance is created and initialized only once.
    /// </remarks>
    public static InMemoryOrderingEvaluator Instance { get; } = new();

    /// <summary>
    /// Evaluates an in-memory collection based on the provided specification and applies ordering if specified.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="query">The in-memory collection to be evaluated.</param>
    /// <param name="spec">The specification defining the criteria and ordering for evaluation.</param>
    /// <returns>A collection of elements that match the specification, with ordering applied if specified.</returns>
    public IEnumerable<T> Evaluate<T>(IEnumerable<T> query, ISpecification<T> spec)
    {
        if (spec.OrderBy is not null)
            return query.OrderBy(spec.OrderBy.Compile());

        if (spec.OrderByDescending is not null)
            return query.OrderByDescending(spec.OrderByDescending.Compile());

        return query;
    }
}