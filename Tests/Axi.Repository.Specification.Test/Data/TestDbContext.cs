using Axi.Repository.Specification.Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Axi.Repository.Specification.Test.Data;

public sealed class TestDbContext(DbContextOptions<TestDbContext> options) : DbContext(options)
{
    public DbSet<PersonRow> People => Set<PersonRow>();
}