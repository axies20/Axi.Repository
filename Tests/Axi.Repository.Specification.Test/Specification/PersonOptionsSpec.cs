using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Test.Specification;

public sealed class PersonOptionsSpec : BaseSpecification<Person>
{
    public void EnableOptions()
    {
        EnableNoTracking();
        EnableSplitQuery();
    }
}