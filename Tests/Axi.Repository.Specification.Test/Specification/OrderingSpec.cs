using Axi.Repository.Specification.Abstractions.Specification;
using Axi.Repository.Specification.Test.Models;

namespace Axi.Repository.Specification.Test.Specification;

public  sealed class OrderingSpec : BaseSpecification<Person>
{
    public OrderingSpec(bool orderDescending)
    {
        if (orderDescending)
            ApplyOrderByDescending(p => p.Age);
        else
            ApplyOrderBy(p => p.Name);
    }
}