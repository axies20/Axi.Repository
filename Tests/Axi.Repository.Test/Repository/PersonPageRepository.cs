using Axi.Repository.Repository;
using Axi.Repository.Test.Models;

namespace Axi.Repository.Test.Repository;

public sealed class PersonPageRepository(TestDbContext dbContext)
    : PagedReadRepositoryBase<PersonRow, TestDbContext>(dbContext)
{
    protected override IOrderedQueryable<PersonRow> OrderByPage(IQueryable<PersonRow> query)
        => query.OrderBy(person => person.Id);
}
