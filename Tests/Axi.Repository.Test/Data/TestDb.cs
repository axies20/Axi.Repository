using Axi.Repository.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Test;

public static class TestDb
{
    public static DbContextOptions<TestDbContext> CreateOptions(string dbName)
        => new DbContextOptionsBuilder<TestDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options;

    public static TestDbContext CreateContext(string dbName)
        => new(CreateOptions(dbName));

    public static async Task SeedPeopleAsync(string dbName)
    {
        await using var db = CreateContext(dbName);
        db.People.AddRange(
            new PersonRow { Id = 1, Name = "Ana", Age = 30 },
            new PersonRow { Id = 2, Name = "Bob", Age = 45 },
            new PersonRow { Id = 3, Name = "Cara", Age = 35 },
            new PersonRow { Id = 4, Name = "Dan", Age = 70 },
            new PersonRow { Id = 5, Name = "Eva", Age = 20 }
        );
        await db.SaveChangesAsync();
        db.ChangeTracker.Clear();
    }
}