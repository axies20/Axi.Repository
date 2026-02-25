using Axi.Repository.Models;
using Axi.Repository.Test.Repository;

namespace Axi.Repository.Test;

public sealed class BaseReadRepositoryTests
{
    [Fact]
    public async Task CountAsync_WithPredicate_FiltersCorrectly()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonReadRepository(db);

        var count = await repo.CountAsync(p => p.Age >= 35);

        Assert.Equal(3, count);
    }

    [Fact]
    public async Task CountAsync_WithoutPredicate_ReturnsTotal()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonReadRepository(db);

        var count = await repo.CountAsync();

        Assert.Equal(5, count);
    }

    [Fact]
    public async Task FirstOrDefaultAsync_ReturnsFirstMatch()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonReadRepository(db);

        var result = await repo.FirstOrDefaultAsync(p => p.Age >= 60);

        Assert.NotNull(result);
        Assert.Equal("Dan", result!.Name);
    }

    [Fact]
    public async Task ListAsync_WithPredicate_ReturnsFilteredList()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonReadRepository(db);

        var list = await repo.ListAsync(p => p.Age < 30);

        Assert.Single(list);
        Assert.Equal("Eva", list[0].Name);
    }

    [Fact]
    public async Task ListAsync_WithPaging_ReturnsExpectedPage()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonReadRepository(db);
        var request = new PageRequest(page: 2, pageSize: 2);

        var result = await repo.ListAsync(p => p.Age >= 20, request);

        Assert.Equal(5, result.TotalCount);
        Assert.Equal(2, result.Items.Count);
        Assert.All(result.Items, item => Assert.True(item.Age >= 20));
        Assert.Equal(2, result.Page);
        Assert.Equal(2, result.PageSize);
    }

    [Fact]
    public async Task AnyAsync_ReturnsTrueWhenMatchExists()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonReadRepository(db);

        var hasAdults = await repo.AnyAsync(p => p.Age >= 18);

        Assert.True(hasAdults);
    }


}
