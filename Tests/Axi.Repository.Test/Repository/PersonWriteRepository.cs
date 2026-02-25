using Axi.Repository.Repository;
using Axi.Repository.Test.Models;

namespace Axi.Repository.Test.Repository;

public sealed class PersonWriteRepository(TestDbContext dbContext)
    : BaseWriteRepository<PersonRow, TestDbContext>(dbContext)
{
}