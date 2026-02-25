using Axi.Repository.Specification.Specification;
using Axi.Repository.Specification.Test.Specification;

namespace Axi.Repository.Specification.Test;

public sealed class BaseSpecificationTests
{
    [Fact]
    public void Include_BuildsNestedPaths()
    {
        var spec = new PersonIncludeSpec();

        spec.AddIncludeChains();

        Assert.Equal(2, spec.IncludePaths.Count);
        Assert.Contains("Address.City", spec.IncludePaths);
        Assert.Contains("Orders.Lines", spec.IncludePaths);
    }

    [Fact]
    public void Include_ThrowsForInvalidExpression()
    {
        var spec = new PersonIncludeSpec();

        var ex = Assert.Throws<InvalidOperationException>(() => spec.AddInvalidInclude());

        Assert.Contains("Expected member access", ex.Message);
    }

    [Fact]
    public void Criteria_ComposesAndOrConditions()
    {
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Ana", Age = 30, IsActive = true },
            new() { Id = 2, Name = "Bob", Age = 70, IsActive = true },
            new() { Id = 3, Name = "VIP Carl", Age = 40, IsActive = false },
            new() { Id = 4, Name = "Dana", Age = 70, IsActive = false }
        };

        var spec = new PersonCriteriaSpec(includeSeniors: true, includeVip: true);
        var evaluator = new InMemorySpecificationEvaluator();

        var result = evaluator.Evaluate(people, spec).ToList();

        Assert.Equal(new[] { 2, 3 }, result.Select(x => x.Id));
    }

    [Fact]
    public void Criteria_WithoutOptionalConditions_ReturnsOnlyActive()
    {
        var people = new List<Person>
        {
            new() { Id = 1, Name = "Ana", Age = 30, IsActive = true },
            new() { Id = 2, Name = "Bob", Age = 70, IsActive = true },
            new() { Id = 3, Name = "VIP Carl", Age = 40, IsActive = false }
        };

        var spec = new PersonCriteriaSpec(includeSeniors: false, includeVip: false);
        var evaluator = new InMemorySpecificationEvaluator();

        var result = evaluator.Evaluate(people, spec).ToList();

        Assert.Equal([1, 2], result.Select(x => x.Id));
    }

    [Fact]
    public void Flags_SettingMethods_ToggleSpecificationOptions()
    {
        var spec = new PersonOptionsSpec();

        spec.EnableOptions();

        Assert.True(spec.AsNoTracking);
        Assert.True(spec.AsSplitQuery);
    }
}