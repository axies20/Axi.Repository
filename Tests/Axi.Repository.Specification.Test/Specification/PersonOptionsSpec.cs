using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Test.Models;

namespace Axi.Repository.Specification.Test.Specification;

public sealed class PersonOptionsSpec : BaseSpecification<Person>
{
    public void EnableOptions()
    {
        EnableNoTracking();
        EnableSplitQuery();
    }
}