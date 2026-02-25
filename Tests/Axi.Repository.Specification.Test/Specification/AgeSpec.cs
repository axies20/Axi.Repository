using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Test.Models;

namespace Axi.Repository.Specification.Test.Specification;

public sealed class AgeSpec : BaseSpecification<PersonRow>
{
    public AgeSpec(int minAge, bool orderByName, bool noTracking = false)
    {
        Where(p => p.Age >= minAge);
        if (orderByName)
            ApplyOrderBy(p => p.Name);
        if (noTracking)
            EnableNoTracking();
    }
}