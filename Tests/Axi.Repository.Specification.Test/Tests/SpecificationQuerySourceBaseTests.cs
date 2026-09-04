using Axi.Repository.Specification.Test.Data;
using Axi.Repository.Specification.Test.Models;
using Axi.Repository.Specification.Test.Repository;
using Axi.Repository.Specification.Test.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Test.Tests;

public sealed class SpecificationQuerySourceBaseTests
{
    [Fact]
    public async Task Query_WithoutSpecification_ReturnsAllEntities()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await SeedPeopleAsync(dbName);

        await using var db = CreateContext(dbName);
        var source = new PersonSpecificationQuerySource(db);

        var result = await source.Query().ToListAsync();

        Assert.Equal(6, result.Count);
    }

    [Fact]
    public async Task Query_WithSpecification_AppliesCriteriaAndOrdering()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await SeedPeopleAsync(dbName);

        await using var db = CreateContext(dbName);
        var source = new PersonSpecificationQuerySource(db);
        var specification = new AgeSpec(minAge: 30, orderByName: true);

        var result = await source.Query(specification).ToListAsync();

        Assert.Equal(["Ana", "Bob", "Cara", "Dan"], result.Select(person => person.Name));
    }

    private static DbContextOptions<TestDbContext> CreateOptions(string dbName)
        => new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options;

    private static TestDbContext CreateContext(string dbName)
        => new(CreateOptions(dbName));

    private static async Task SeedPeopleAsync(string dbName)
    {
        await using var db = CreateContext(dbName);
        db.People.AddRange(
            new PersonRow { Id = 1, Name = "Ana", Age = 30, IsActive = true },
            new PersonRow { Id = 2, Name = "Bob", Age = 50, IsActive = false },
            new PersonRow { Id = 3, Name = "Cara", Age = 35, IsActive = true },
            new PersonRow { Id = 4, Name = "Dan", Age = 70, IsActive = true },
            new PersonRow { Id = 5, Name = "Eva", Age = 25, IsActive = false },
            new PersonRow { Id = 6, Name = "Frank", Age = 18, IsActive = true });
        await db.SaveChangesAsync();
    }
}
