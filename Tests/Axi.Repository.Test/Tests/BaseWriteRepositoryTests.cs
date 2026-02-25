using Axi.Repository.Test.Models;
using Axi.Repository.Test.Repository;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Test;

public sealed class BaseWriteRepositoryTests
{
    [Fact]
    public async Task Add_AddsEntityToContext()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonWriteRepository(db);

        repo.Add(new PersonRow { Id = 1, Name = "Ana", Age = 30 });
        await db.SaveChangesAsync();

        Assert.Equal(1, await db.People.CountAsync());
    }

    [Fact]
    public async Task AddAsync_AddsEntityToContext()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonWriteRepository(db);

        await repo.AddAsync(new PersonRow { Id = 1, Name = "Bob", Age = 40 }, CancellationToken.None);
        await db.SaveChangesAsync();

        var names = await db.People.Select(x => x.Name).ToListAsync();
        Assert.Equal(new[] { "Bob" }, names);
    }

    [Fact]
    public async Task AddRange_AddsMultipleEntities()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonWriteRepository(db);

        repo.AddRange(new[]
        {
            new PersonRow { Id = 1, Name = "Ana", Age = 30 },
            new PersonRow { Id = 2, Name = "Cara", Age = 25 }
        });
        await db.SaveChangesAsync();

        Assert.Equal(2, await db.People.CountAsync());
    }

    [Fact]
    public async Task AddRangeAsync_AddsMultipleEntities()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonWriteRepository(db);

        await repo.AddRangeAsync(new[]
        {
            new PersonRow { Id = 1, Name = "Dan", Age = 45 },
            new PersonRow { Id = 2, Name = "Eva", Age = 20 }
        }, CancellationToken.None);
        await db.SaveChangesAsync();

        var names = await db.People.OrderBy(x => x.Id).Select(x => x.Name).ToListAsync();
        Assert.Equal(new[] { "Dan", "Eva" }, names);
    }

    [Fact]
    public async Task Update_ChangesEntityValues()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonWriteRepository(db);
        var entity = await db.People.FirstAsync(x => x.Name == "Ana");
        entity.Age = 31;

        repo.Update(entity);
        await db.SaveChangesAsync();

        var updated = await db.People.FirstAsync(x => x.Name == "Ana");
        Assert.Equal(31, updated.Age);
    }

    [Fact]
    public async Task UpdateRange_ChangesMultipleEntities()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonWriteRepository(db);
        var entities = await db.People.Where(x => x.Age < 30).ToListAsync();
        foreach (var e in entities)
            e.Age += 10;

        repo.UpdateRange(entities);
        await db.SaveChangesAsync();

        var ages = await db.People.Where(x => x.Name == "Eva").Select(x => x.Age).SingleAsync();
        Assert.Equal(30, ages);
    }

    [Fact]
    public async Task Delete_RemovesEntity()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await TestDb.SeedPeopleAsync(dbName);

        await using var db = TestDb.CreateContext(dbName);
        var repo = new PersonWriteRepository(db);
        var entity = await db.People.FirstAsync(x => x.Name == "Bob");

        repo.Delete(entity);
        await db.SaveChangesAsync();

        Assert.False(await db.People.AnyAsync(x => x.Name == "Bob"));
    }
}