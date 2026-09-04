using Axi.Repository.Models;
using Axi.Repository.Test.Data;
using Axi.Repository.Test.Repository;

namespace Axi.Repository.Test.Tests;

public sealed class CursorReadRepositoryBaseTests
{
    [Fact]
    public async Task ListAsync_FirstPage_ReturnsItemsAndNextCursor()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repository = new PersonCursorRepository(db);

        var result = await repository.ListAsync(
            person => person.Age >= 20,
            new CursorRequest<int>(After: null, Size: 2));

        Assert.Equal([1, 2], result.Items.Select(person => person.Id));
        Assert.Equal(2, result.NextCursor);
    }

    [Fact]
    public async Task ListAsync_AfterCursor_ReturnsNextPage()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repository = new PersonCursorRepository(db);

        var result = await repository.ListAsync(
            person => person.Age >= 20,
            new CursorRequest<int>(After: 2, Size: 2));

        Assert.Equal([3, 4], result.Items.Select(person => person.Id));
        Assert.Equal(4, result.NextCursor);
    }

    [Fact]
    public async Task ListAsync_LastPage_ReturnsNullCursor()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repository = new PersonCursorRepository(db);

        var result = await repository.ListAsync(
            person => person.Age >= 20,
            new CursorRequest<int>(After: 4, Size: 2));

        Assert.Equal([5], result.Items.Select(person => person.Id));
        Assert.Null(result.NextCursor);
    }

    [Fact]
    public async Task ListAsync_InvalidSize_Throws()
    {
        await using var db = TestDb.CreateContext(Guid.NewGuid().ToString("N"));
        var repository = new PersonCursorRepository(db);

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() =>
            repository.ListAsync(
                person => true,
                new CursorRequest<int>(After: null, Size: 0)));
    }
}
