using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Test.Models;

namespace Axi.Repository.Specification.Test.Specification;

public sealed class AgeDescSpec : BaseSpecification<PersonRow>
{
    public AgeDescSpec(int minAge)
    {
        Where(p => p.Age >= minAge);
        ApplyOrderByDescending(p => p.Age);
    }
}