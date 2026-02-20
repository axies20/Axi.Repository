namespace Axi.Repository.Models;

/// <summary>
/// Represents a result set for paginated data, including the items,
/// total count, current page, and page size.
/// </summary>
/// <typeparam name="T">The type of items contained in the paginated result.</typeparam>
public record PagedResult<T>(IReadOnlyList<T> Items, int TotalCount, int Page, int PageSize)
{
    /// <summary>
    /// Gets the total number of pages based on the total count of items and the page size.
    /// </summary>
    /// <remarks>
    /// The value is calculated by dividing the total count of items by the page size and rounding up
    /// to the nearest whole number to account for any remaining items.
    /// </remarks>
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
}