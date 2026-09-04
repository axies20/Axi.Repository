using Axi.Repository.Models;
using Axi.Repository.Test.Data;
using Axi.Repository.Test.Repository;

namespace Axi.Repository.Test.Tests;

public sealed class PagedReadRepositoryBaseTests
{
    [Fact]
    public async Task ListAsync_ReturnsDeterministicPageAndMetadata()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repository = new PersonPageRepository(db);

        var result = await repository.ListAsync(
            person => person.Age >= 20,
            new PageRequest(page: 2, pageSize: 2));

        Assert.Equal([3, 4], result.Items.Select(person => person.Id));
        Assert.Equal(5, result.TotalCount);
        Assert.Equal(2, result.Page);
        Assert.Equal(2, result.PageSize);
        Assert.Equal(3, result.TotalPages);
    }

    [Fact]
    public async Task ListAsync_AppliesPredicateBeforeCountingAndPaging()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repository = new PersonPageRepository(db);

        var result = await repository.ListAsync(
            person => person.Age >= 35,
            new PageRequest(page: 1, pageSize: 2));

        Assert.Equal([2, 3], result.Items.Select(person => person.Id));
        Assert.Equal(3, result.TotalCount);
        Assert.Equal(2, result.TotalPages);
    }
}
