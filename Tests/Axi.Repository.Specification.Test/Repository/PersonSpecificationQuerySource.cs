using Axi.Repository.Specification.Repository;
using Axi.Repository.Specification.Test.Data;
using Axi.Repository.Specification.Test.Models;

namespace Axi.Repository.Specification.Test.Repository;

public sealed class PersonSpecificationQuerySource(TestDbContext dbContext)
    : SpecificationQuerySourceBase<PersonRow, TestDbContext>(dbContext)
{
}
