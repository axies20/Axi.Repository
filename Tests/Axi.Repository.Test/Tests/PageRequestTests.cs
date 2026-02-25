using Axi.Repository.Models;

namespace Axi.Repository.Test;

public sealed class PageRequestTests
{
    [Fact]
    public void Constructor_ClampsPageAndPageSize()
    {
        var request = new PageRequest(page: 0, pageSize: 999, maxPageSize: 50);

        Assert.Equal(1, request.Page);
        Assert.Equal(50, request.PageSize);
    }

    [Fact]
    public void Constructor_ClampsPageSizeToMinimum()
    {
        var request = new PageRequest(page: 2, pageSize: 0, maxPageSize: 10);

        Assert.Equal(2, request.Page);
        Assert.Equal(1, request.PageSize);
    }
}
