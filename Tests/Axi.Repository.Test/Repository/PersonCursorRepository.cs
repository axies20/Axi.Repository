using Axi.Repository.Repository;
using Axi.Repository.Test.Data;
using Axi.Repository.Test.Models;

namespace Axi.Repository.Test.Repository;

public sealed class PersonCursorRepository(TestDbContext dbContext)
    : CursorReadRepositoryBase<PersonRow, int, TestDbContext>(dbContext)
{
    protected override IQueryable<PersonRow> ApplyAfter(IQueryable<PersonRow> query, int cursor)
        => query.Where(person => person.Id > cursor);

    protected override IOrderedQueryable<PersonRow> OrderByCursor(IQueryable<PersonRow> query)
        => query.OrderBy(person => person.Id);

    protected override int GetCursor(PersonRow entity)
        => entity.Id;
}
