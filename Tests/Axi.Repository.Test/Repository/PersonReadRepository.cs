using Axi.Repository.Repository;
using Axi.Repository.Test.Data;
using Axi.Repository.Test.Models;

namespace Axi.Repository.Test.Repository;

public sealed class PersonReadRepository(TestDbContext dbContext)
    : ReadRepositoryBase<PersonRow, TestDbContext>(dbContext)
{
}
