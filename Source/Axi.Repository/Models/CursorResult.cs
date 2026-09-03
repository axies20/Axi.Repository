namespace Axi.Repository.Models;

/// <summary>
/// Represents a paginated result set with items and a cursor indicating the next set of results.
/// </summary>
/// <typeparam name="T">
/// The type of the items in the result set.
/// </typeparam>
/// <typeparam name="TCursor">
/// The type of the cursor used to retrieve the next set of results.
/// </typeparam>
/// <param name="Items">The items returned for the current page.</param>
/// <param name="NextCursor">
/// The exclusive boundary for the next request, or <see langword="null"/> when no more items are available.
/// </param>
public sealed record CursorResult<T, TCursor>(IReadOnlyList<T> Items, TCursor? NextCursor)
    where TCursor : struct;
