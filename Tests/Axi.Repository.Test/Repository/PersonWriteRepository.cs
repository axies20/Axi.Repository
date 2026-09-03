using Axi.Repository.Repository;
using Axi.Repository.Test.Models;

namespace Axi.Repository.Test.Repository;

public sealed class PersonWriteRepository(TestDbContext dbContext)
    : WriteRepositoryBase<PersonRow, TestDbContext>(dbContext)
{
}
