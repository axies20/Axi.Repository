# Axi.Repository

A modern .NET library implementing Repository and Specification patterns for Entity Framework Core applications.
Provides clean abstractions for data access with built-in support for filtering, pagination, eager loading, and complex
queries.

## Features

- **Repository Pattern**: Generic read/write repository interfaces with base implementations
- **Specification Pattern**: Type-safe query specifications with fluent API
- **Pagination Support**: Offset and cursor-based pagination with deterministic ordering
- **Eager Loading**: Expression-based include paths for related entities
- **Query Optimization**: No-tracking queries and split query support
- **Unit of Work**: Persistence coordination with `IUnitOfWork`
- **.NET 10.0**: Built for the latest .NET platform
- **EF Core 10.0**: Full Entity Framework Core support

## Projects

### Axi.Repository

Core repository abstractions and base implementations:

- `IReadRepository<T>` / `ReadRepositoryBase<T, TDbContext>` - Read operations
- `IPagedReadRepository<T>` / `PagedReadRepositoryBase<T, TDbContext>` - Offset pagination
- `ICursorReadRepository<T, TCursor>` / `CursorReadRepositoryBase<T, TCursor, TDbContext>` - Keyset pagination
- `IWriteRepository<T>` / `WriteRepositoryBase<T, TDbContext>` - Write operations
- `IUnitOfWork` / `UnitOfWorkBase<TDbContext>` - Save and lifetime management
- `PageRequest` / `PagedResult<T>` - Pagination models

### Axi.Repository.Specification

Specification pattern implementation for EF Core:

- `ISpecification<T>` - Query specification interface
- `BaseSpecification<T>` - Fluent specification builder
- `ISpecificationReadRepository<T>` - Repository with specification support
- `SpecificationReadRepositoryBase<T, TDbContext>` - EF Core specification repository base
- Built-in evaluators for criteria, ordering, includes, split queries

## Installation

```bash
# Core repository package
dotnet add package Axi.Repository

# Specification support
dotnet add package Axi.Repository.Specification
```

## Quick Start

### 1. Define Your Entity

```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
}
```

### 2. Create Repository

```csharp
public class ProductRepository : SpecificationReadRepositoryBase<Product, YourDbContext>
{
    public ProductRepository(YourDbContext context) : base(context) { }
}
```

### 3. Build Specification

```csharp
public class ActiveProductsSpec : BaseSpecification<Product>
{
    public ActiveProductsSpec(decimal minPrice)
    {
        Where(p => p.Price >= minPrice);
        Include(p => p.Category);
        ApplyOrderByDescending(p => p.Price);
        EnableNoTracking();
    }
}
```

### 4. Query Data

```csharp
// Using specification
var spec = new ActiveProductsSpec(minPrice: 100);
var products = await repository.ListAsync(spec, cancellationToken);

// Paginated query
var pageRequest = new PageRequest(page: 1, pageSize: 20);
var pagedResult = await repository.ListAsync(spec, pageRequest, cancellationToken);

// Simple predicate
var product = await repository.FirstOrDefaultAsync(
    p => p.Id == productId,
    cancellationToken
);
```

## Core Interfaces

### IReadRepository<T>

```csharp
Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
Task<int> CountAsync(CancellationToken ct = default);
Task<long> LongCountAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
Task<long> LongCountAsync(CancellationToken ct = default);
Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct = default);
```

### Pagination repositories

```csharp
Task<PagedResult<T>> ListAsync(
    Expression<Func<T, bool>> predicate,
    PageRequest page,
    CancellationToken ct = default);

Task<CursorResult<T, TCursor>> ListAsync(
    Expression<Func<T, bool>> predicate,
    CursorRequest<TCursor> request,
    CancellationToken ct = default);
```

Derived page repositories provide `OrderByPage`. Derived cursor repositories provide
`ApplyAfter`, `OrderByCursor`, and `GetCursor`, allowing simple or composite value-type cursors.

### IWriteRepository<T>

```csharp
void Add(T entity);
Task AddAsync(T entity, CancellationToken cancellationToken);
void AddRange(IEnumerable<T> entities);
Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
void Update(T entity);
void UpdateRange(IEnumerable<T> entities);
void Delete(T entity);
```

### ISpecification<T>

```csharp
Expression<Func<T, bool>>? Criteria { get; }
IReadOnlyList<string> IncludePaths { get; }
Expression<Func<T, object>>? OrderBy { get; }
Expression<Func<T, object>>? OrderByDescending { get; }
bool AsSplitQuery { get; }
bool AsNoTracking { get; }
```

## Specification Pattern

Build complex queries with a fluent API:

```csharp
public class ProductsByCategory : BaseSpecification<Product>
{
    public ProductsByCategory(int categoryId, bool includeRelated = false)
    {
        // Filter criteria
        Where(p => p.CategoryId == categoryId);
        Where(p => p.IsActive);

        // Eager loading
        if (includeRelated)
        {
            Include(p => p.Category);
            IncludeMany(p => p.Reviews);
        }

        // Ordering
        ApplyOrderBy(p => p.Name);

        // Performance optimization
        EnableNoTracking();
        EnableSplitQuery();
    }
}
```

## Pagination

```csharp
var pageRequest = new PageRequest(
    page: 1,          // Page number (minimum 1)
    pageSize: 20,     // Items per page
    maxPageSize: 100  // Maximum allowed page size
);

var result = await repository.ListAsync(predicate, pageRequest, ct);

// PagedResult<T> contains:
// - List<T> Items
// - int TotalCount
// - int Page
// - int PageSize
// - int TotalPages
```

## Unit of Work

```csharp
public class OrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWriteRepository<Order> _orderRepo;

    public async Task CreateOrder(Order order, CancellationToken ct)
    {
        _orderRepo.Add(order);
        await _unitOfWork.SaveChangesAsync(ct);
    }
}
```

## Advanced Features

### In-Memory Specification Evaluator

Apply specifications to in-memory collections:

```csharp
var spec = new ActiveProductsSpec(minPrice: 100);
var filteredProducts = inMemoryEvaluator.Evaluate(products, spec);
```

### Query Evaluators

- `CriteriaEvaluator` - Applies filter expressions
- `IncludePathsEvaluator` - Handles eager loading
- `OrderingEvaluator` - Applies sorting
- `NoTrackingEvaluator` - Optimizes read-only queries
- `SplitQueryEvaluator` - Prevents cartesian explosion

## Dependencies

- **.NET 10.0** or later
- **Microsoft.EntityFrameworkCore 10.0.3** (Specification package)
- **LinqKit.Microsoft.EntityFrameworkCore 10.0.11** (Core package)

## License

MIT License – see [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests.

## Support

For questions and support, please open an issue on the GitHub repository.
