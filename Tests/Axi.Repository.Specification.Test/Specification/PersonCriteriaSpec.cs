using Axi.Repository.Specification.Abstractions.Specification;

namespace Axi.Repository.Specification.Test.Specification;

public sealed class PersonCriteriaSpec : BaseSpecification<Person>
{
    public PersonCriteriaSpec(bool includeSeniors, bool includeVip)
    {
        Where(p => p.IsActive);
        WhereIf(includeSeniors, p => p.Age >= 65);
        OrWhereIf(includeVip, p => p.Name.StartsWith("VIP"));
    }
}