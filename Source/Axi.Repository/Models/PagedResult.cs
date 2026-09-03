namespace Axi.Repository.Models;

/// <summary>
/// Paginated result containing items and metadata.
/// </summary>
/// <typeparam name="T">The type of item in the result.</typeparam>
/// <param name="Items">The items returned for the requested page.</param>
/// <param name="TotalCount">The total number of matching items across all pages.</param>
/// <param name="Page">The one-based page number.</param>
/// <param name="PageSize">The maximum number of items requested per page.</param>
public sealed record PagedResult<T>(IReadOnlyList<T> Items, int TotalCount, int Page, int PageSize)
{
    /// <summary>
    /// Gets the total number of pages required for all matching items.
    /// </summary>
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}
