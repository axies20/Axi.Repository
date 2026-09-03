namespace Axi.Repository.Models;

/// <summary>
/// Represents a request for paginated data using a cursor-based mechanism.
/// </summary>
/// <typeparam name="TCursor">The value type that identifies a cursor position.</typeparam>
/// <param name="After">The exclusive cursor boundary, or <see langword="null"/> for the first page.</param>
/// <param name="Size">The requested page size. It must be greater than zero.</param>
public sealed record CursorRequest<TCursor>(
    TCursor? After,
    int Size)
    where TCursor : struct;
