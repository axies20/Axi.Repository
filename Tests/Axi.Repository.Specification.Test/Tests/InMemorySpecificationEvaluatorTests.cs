using Axi.Repository.Specification.Specification;
using Axi.Repository.Specification.Test.Specification;

namespace Axi.Repository.Specification.Test;

public sealed class InMemorySpecificationEvaluatorTests
{
    [Fact]
    public void Evaluate_OrdersAscendingByName()
    {
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Zoe", Age = 28, IsActive = true },
            new() { Id = 2, Name = "Ana", Age = 35, IsActive = true },
            new() { Id = 3, Name = "Bob", Age = 42, IsActive = true }
        };

        var spec = new OrderingSpec(orderDescending: false);
        var evaluator = new InMemorySpecificationEvaluator();

        var result = evaluator.Evaluate(people, spec).ToList();

        Assert.Equal(new[] { "Ana", "Bob", "Zoe" }, result.Select(x => x.Name));
    }

    [Fact]
    public void Evaluate_OrdersDescendingByAge()
    {
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Ana", Age = 28, IsActive = true },
            new() { Id = 2, Name = "Bob", Age = 42, IsActive = true },
            new() { Id = 3, Name = "Cara", Age = 35, IsActive = true }
        };

        var spec = new OrderingSpec(orderDescending: true);
        var evaluator = new InMemorySpecificationEvaluator();

        var result = evaluator.Evaluate(people, spec).ToList();

        Assert.Equal(new[] { 42, 35, 28 }, result.Select(x => x.Age));
    }

    [Fact]
    public void Evaluate_UsesOrderByWhenBothAreSet()
    {
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Zoe", Age = 28, IsActive = true },
            new() { Id = 2, Name = "Ana", Age = 99, IsActive = true },
            new() { Id = 3, Name = "Bob", Age = 10, IsActive = true }
        };

        var spec = new BothOrderingsSpec();
        var evaluator = new InMemorySpecificationEvaluator();

        var result = evaluator.Evaluate(people, spec).ToList();

        Assert.Equal(new[] { "Ana", "Bob", "Zoe" }, result.Select(x => x.Name));
    }

    [Fact]
    public void Evaluate_NoCriteriaAndNoOrdering_ReturnsOriginalSequence()
    {
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Ana", Age = 28, IsActive = true },
            new() { Id = 2, Name = "Bob", Age = 42, IsActive = true }
        };

        var spec = new EmptySpec();
        var evaluator = new InMemorySpecificationEvaluator();

        var result = evaluator.Evaluate(people, spec);

        Assert.Same(people, result);
    }
}