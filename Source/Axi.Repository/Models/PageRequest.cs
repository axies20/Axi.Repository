namespace Axi.Repository.Models;

/// <summary>
/// Pagination request with validated page number and size.
/// </summary>
public sealed record PageRequest
{
    /// <summary>
    /// Initializes a request and clamps the page and page size to their supported ranges.
    /// </summary>
    /// <param name="page">The one-based page number.</param>
    /// <param name="pageSize">The requested number of items per page.</param>
    /// <param name="maxPageSize">The maximum permitted page size.</param>
    /// <exception cref="ArgumentException"><paramref name="maxPageSize"/> is less than one.</exception>
    public PageRequest(int page = 1, int pageSize = 50, int maxPageSize = 100)
    {
        Page = Math.Max(1, page);
        PageSize = Math.Clamp(pageSize, 1, maxPageSize);
    }

    /// <summary>
    /// Gets the one-based page number.
    /// </summary>
    public int Page { get; }

    /// <summary>
    /// Gets the clamped number of items requested per page.
    /// </summary>
    public int PageSize { get; }
}
