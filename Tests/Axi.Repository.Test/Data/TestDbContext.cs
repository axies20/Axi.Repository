using Axi.Repository.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Test;

public sealed class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    public DbSet<PersonRow> People => Set<PersonRow>();
}