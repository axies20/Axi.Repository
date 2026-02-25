using Axi.Repository.Models;

namespace Axi.Repository.Test;

public sealed class PagedResultTests
{
    [Fact]
    public void TotalPages_ComputesCeiling()
    {
        var items = new[] { 1, 2, 3 };
        var result = new PagedResult<int>(items, 11, 1, 5);

        Assert.Equal(3, result.TotalPages);
    }

    [Fact]
    public void TotalPages_WithExactDivision_IsExact()
    {
        var items = new[] { "A", "B" };
        var result = new PagedResult<string>(items, 10, 2, 5);

        Assert.Equal(2, result.TotalPages);
    }
}