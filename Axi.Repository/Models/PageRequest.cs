namespace Axi.Repository.Models;

/// <summary>
/// Represents a request for paginated data.
/// Encapsulates page number and page size with validation.
/// </summary>
public record PageRequest
{
    /// <summary>
    /// Represents a request for paginated data with options for page number and page size.
    /// </summary>
    /// <remarks>
    /// The page number and page size are validated during initialization.
    /// The page number defaults to 1, and the page size defaults to 50 unless overridden.
    /// The page size is clamped to respect a maximum size limit.
    /// </remarks>
    public PageRequest(int page = 1, int pageSize = 50, int maxPageSize = 100)
    {
        Page = Math.Max(1, page);
        PageSize = Math.Clamp(pageSize, 1, maxPageSize);
    }

    /// <summary>
    /// Represents the current page number within a paginated data structure.
    /// The value specifies which page of data to retrieve, adhering to a minimum value of 1 to ensure valid pagination.
    /// </summary>
    public int Page { get; }

    /// <summary>
    /// Specifies the number of items to include on each page of a paginated data structure.
    /// The value is subject to validation to ensure it adheres to a minimum and maximum range,
    /// preventing invalid page size configurations.
    /// </summary>
    public int PageSize { get; }
}