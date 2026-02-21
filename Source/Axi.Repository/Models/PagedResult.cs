namespace Axi.Repository.Models;

/// <summary>
/// Paginated result containing items and metadata.
/// </summary>
/// <typeparam name="T">Item type.</typeparam>
public record PagedResult<T>(IReadOnlyList<T> Items, int TotalCount, int Page, int PageSize)
{
    /// <summary>
    /// Total number of pages.
    /// </summary>
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}