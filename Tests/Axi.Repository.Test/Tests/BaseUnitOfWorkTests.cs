using Axi.Repository.Repository;
using Axi.Repository.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Test;

public sealed class BaseUnitOfWorkTests
{
    [Fact]
    public async Task SaveChanges_PersistsChanges()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await using var db = TestDb.CreateContext(dbName);
        var uow = new PersonUnitOfWork(db);

        db.People.Add(new PersonRow { Id = 1, Name = "Ana", Age = 30 });
        uow.SaveChanges();

        Assert.Equal(1, await db.People.CountAsync());
    }

    [Fact]
    public async Task SaveChangesAsync_PersistsChanges()
    {
        var dbName = Guid.NewGuid().ToString("N");
        await using var db = TestDb.CreateContext(dbName);
        var uow = new PersonUnitOfWork(db);

        db.People.Add(new PersonRow { Id = 1, Name = "Bob", Age = 40 });
        var written = await uow.SaveChangesAsync();

        Assert.Equal(1, written);
        Assert.True(await db.People.AnyAsync(x => x.Name == "Bob"));
    }

    private sealed class PersonUnitOfWork(TestDbContext dbContext)
        : BaseUnitOfWork<TestDbContext>(dbContext)
    {
    }
}