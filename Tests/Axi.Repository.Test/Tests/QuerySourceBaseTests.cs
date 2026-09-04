using Axi.Repository.Test.Data;
using Axi.Repository.Test.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Test.Tests;

public sealed class QuerySourceBaseTests
{
    [Fact]
    public async Task Query_WithoutPredicate_ReturnsAllEntities()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var source = new PersonQuerySource(db);

        var result = await source.Query().ToListAsync();

        Assert.Equal(5, result.Count);
    }

    [Fact]
    public async Task Query_WithPredicate_AppliesFilter()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var source = new PersonQuerySource(db);

        var result = await source.Query(person => person.Age >= 40).ToListAsync();

        Assert.Equal([2, 4], result.Select(person => person.Id));
    }
}
