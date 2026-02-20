namespace Axi.Repository.Models;

/// <summary>
/// Pagination request with validated page number and size.
/// </summary>
public record PageRequest
{
    /// <summary>
    /// Initializes pagination request with validated parameters.
    /// </summary>
    public PageRequest(int page = 1, int pageSize = 50, int maxPageSize = 100)
    {
        Page = Math.Max(1, page);
        PageSize = Math.Clamp(pageSize, 1, maxPageSize);
    }

    /// <summary>
    /// Page number (minimum 1).
    /// </summary>
    public int Page { get; }

    /// <summary>
    /// Items per page.
    /// </summary>
    public int PageSize { get; }
}