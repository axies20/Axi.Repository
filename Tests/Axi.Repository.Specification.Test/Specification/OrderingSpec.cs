using Axi.Repository.Specification.Abstractions.Specification;

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