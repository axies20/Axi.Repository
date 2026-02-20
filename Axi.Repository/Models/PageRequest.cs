namespace Axi.Repository.Models;

public record PageRequest
{
    public PageRequest(int page = 1, int pageSize = 50, int maxPageSize = 100)
    {
        Page = Math.Max(1, page);
        PageSize = Math.Clamp(pageSize, 1, maxPageSize);
    }

    public int Page { get; }
    public int PageSize { get; }
}