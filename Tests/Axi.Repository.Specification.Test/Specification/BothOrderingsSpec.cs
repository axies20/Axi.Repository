using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Test.Specification;

public sealed class BothOrderingsSpec : BaseSpecification<Person>
{
    public BothOrderingsSpec()
    {
        ApplyOrderBy(p => p.Name);
        ApplyOrderByDescending(p => p.Age);
    }
}