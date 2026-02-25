using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Test.Specification;

public sealed class PersonIncludeSpec : BaseSpecification<Person>
{
    public void AddIncludeChains()
    {
        Include(p => p.Address).Then(a => a.City);
        IncludeMany(p => p.Orders).ThenMany(o => o.Lines);
    }

    public void AddInvalidInclude()
        => Include(p => p.Address.City.ToString());
}