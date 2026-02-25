using Axi.Repository.Models;
using Axi.Repository.Specification.Test.Data;
using Axi.Repository.Specification.Test.Models;
using Axi.Repository.Specification.Test.Repository;
using Axi.Repository.Specification.Test.Specification;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Test;

public sealed class SpecificationReadRepositoryTests
{
    [Fact]
    public async Task FirstOrDefaultAsync_RespectsOrdering()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await SeedPeopleAsync(dbName);

        await using var db = CreateContext(dbName);
        var repo = new PersonRepository(db);
        var spec = new AgeSpec(minAge: 30, orderByName: true);

        var result = await repo.FirstOrDefaultAsync(spec);

        Assert.NotNull(result);
        Assert.Equal("Ana", result!.Name);
    }

    [Fact]
    public async Task CountAsync_UsesCriteriaOnly()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await SeedPeopleAsync(dbName);

        await using var db = CreateContext(dbName);
        var repo = new PersonRepository(db);
        var spec = new AgeSpec(minAge: 50, orderByName: true);

        var count = await repo.CountAsync(spec);

        Assert.Equal(2, count);
    }

    [Fact]
    public async Task ListAsync_Paged_ReturnsExpectedItemsAndTotal()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await SeedPeopleAsync(dbName);

        await using var db = CreateContext(dbName);
        var repo = new PersonRepository(db);
        var spec = new AgeDescSpec(minAge: 25);
        var page = new PageRequest(page: 2, pageSize: 2);

        var result = await repo.ListAsync(spec, page);

        Assert.Equal(5, result.TotalCount);
        Assert.Equal(2, result.Items.Count);
        Assert.Equal([35, 30], result.Items.Select(x => x.Age));
    }

    [Fact]
    public async Task ListAsync_NoTracking_DoesNotTrackEntities()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await SeedPeopleAsync(dbName);

        await using var db = CreateContext(dbName);
        var repo = new PersonRepository(db);
        var spec = new AgeSpec(minAge: 20, orderByName: false, noTracking: true);

        var _ = await repo.ListAsync(spec);

        Assert.Empty(db.ChangeTracker.Entries<PersonRow>());
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
            new PersonRow { Id = 6, Name = "Frank", Age = 18, IsActive = true }
        );
        await db.SaveChangesAsync();
        db.ChangeTracker.Clear();
    }
}