# Graph Report - Axi.Repository  (2026-09-04)

## Corpus Check
- 81 files · ~9,169 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 535 nodes · 1075 edges · 18 communities (15 shown, 3 thin omitted)
- Extraction: 88% EXTRACTED · 12% INFERRED · 0% AMBIGUOUS · INFERRED: 128 edges (avg confidence: 0.84)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `e2655c02`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Axi.Repository.Specification.Abstractions.Specification
- .CreateContext
- BaseSpecification
- ISpecification
- Axi.Repository.Abstractions.Repository
- PersonRow
- Axi.Repository.Models
- Person
- .ListAsync
- Axi.Repository.Specification.Test.csproj
- WriteRepositoryBase
- Axi.Repository Core Package
- Axi.Repository.Repository
- ReadRepositoryBase
- Order
- buildNuget.sh
- NoTrackingEvaluator
- Split Queries

## God Nodes (most connected - your core abstractions)
1. `BaseSpecification` - 39 edges
2. `ISpecification` - 32 edges
3. `Axi.Repository.Specification.Abstractions.Specification` - 29 edges
4. `Axi.Repository.Specification.Test.Models` - 21 edges
5. `PersonRow` - 21 edges
6. `Axi.Repository.Models` - 16 edges
7. `Person` - 16 edges
8. `TestDbContext` - 14 edges
9. `Axi.Repository.Abstractions.Repository` - 13 edges
10. `Axi.Repository.Repository` - 13 edges

## Surprising Connections (you probably didn't know these)
- `AgeDescSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/AgeDescSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `AgeSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/AgeSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `BothOrderingsSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/BothOrderingsSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `EmptySpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/EmptySpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `OrderingSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/OrderingSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Paginated Repository Query** — readme_ibasereadrepository, readme_pagerequest, readme_pagedresult [EXTRACTED 1.00]
- **Repository Specification Query Flow** — readme_basespecification, readme_specificationreadrepository, readme_ispecification [EXTRACTED 1.00]

## Communities (18 total, 3 thin omitted)

### Community 0 - "Axi.Repository.Specification.Abstractions.Specification"
Cohesion: 0.06
Nodes (38): Axi.Repository.Specification.Evaluators, Axi.Repository.Specification.Abstractions.Specification, Axi.Repository.Specification.Specification, Axi.Repository.Specification.Test.Repository, Axi.Repository.Specification.Test.Specification, Axi.Repository.Specification.Repository, Axi.Repository.Specification.Test.Tests, Axi.Repository.Specification.Abstractions.Repository (+30 more)

### Community 1 - ".CreateContext"
Cohesion: 0.09
Nodes (33): ArgumentOutOfRangeException, CursorRequest, TestDb, DbContextOptions, Task, TestDbContext, People, DbContextOptions (+25 more)

### Community 2 - "BaseSpecification"
Cohesion: 0.07
Nodes (24): ExpressionStarter, IncludeChain, InvalidOperationException, AsNoTracking, AsSplitQuery, Criteria, IncludePaths, OrderBy (+16 more)

### Community 3 - "ISpecification"
Cohesion: 0.06
Nodes (29): IQueryable, IQueryable, ISpecificationReadRepository, CancellationToken, List, Task, ISpecification, AsNoTracking (+21 more)

### Community 4 - "Axi.Repository.Abstractions.Repository"
Cohesion: 0.06
Nodes (23): Axi.Repository.Abstractions.Repository, IAsyncDisposable, IDisposable, IQuerySource, Expression, Func, IQueryable, IUnitOfWork (+15 more)

### Community 5 - "PersonRow"
Cohesion: 0.11
Nodes (25): DbContext, SpecificationQuerySourceBase, DbContext, IQueryable, TestDbContext, People, DbContextOptions, DbSet (+17 more)

### Community 6 - "Axi.Repository.Models"
Cohesion: 0.07
Nodes (23): Axi.Repository.Models, IPagedReadRepository, CancellationToken, Expression, Func, Task, PagedResult, TotalPages (+15 more)

### Community 7 - "Person"
Cohesion: 0.09
Nodes (23): IInMemorySpecificationEvaluator, IEnumerable, InMemorySpecificationEvaluator, IEnumerable, Address, City, Street, Person (+15 more)

### Community 8 - ".ListAsync"
Cohesion: 0.10
Nodes (19): ICursorReadRepository, CancellationToken, Expression, Func, Task, IReadRepository, CancellationToken, Expression (+11 more)

### Community 9 - "Axi.Repository.Specification.Test.csproj"
Cohesion: 0.08
Nodes (24): AutoFixture, AutoFixture.Xunit2, LinqKit.Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Relational, Moq, net10.0, Microsoft.NET.Sdk (+16 more)

### Community 10 - "WriteRepositoryBase"
Cohesion: 0.15
Nodes (8): IWriteRepository, CancellationToken, IEnumerable, Task, WriteRepositoryBase, CancellationToken, IEnumerable, Task

### Community 11 - "Axi.Repository Core Package"
Cohesion: 0.11
Nodes (22): Axi.Repository Core Package, Axi.Repository Library, Axi.Repository.Specification Package, BaseSpecification<T>, CriteriaEvaluator, Eager Loading, Entity Framework Core, IBaseReadRepository<T> (+14 more)

### Community 12 - "Axi.Repository.Repository"
Cohesion: 0.26
Nodes (5): Axi.Repository.Test.Models, Axi.Repository.Repository, Axi.Repository.Test.Data, Axi.Repository.Test.Tests, Axi.Repository.Test.Repository

### Community 13 - "ReadRepositoryBase"
Cohesion: 0.27
Nodes (10): ReadRepositoryBase, DbContext, CancellationToken, Expression, Func, Task, PersonReadRepository, ReadRepositoryBaseTests (+2 more)

### Community 14 - "Order"
Cohesion: 0.18
Nodes (9): Order, Id, Lines, Total, List, OrderLine, Id, Quantity (+1 more)

## Knowledge Gaps
- **93 isolated node(s):** `IsCriteriaEvaluator`, `Criteria`, `IncludePaths`, `OrderBy`, `OrderByDescending` (+88 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **3 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `ISpecification` connect `ISpecification` to `Axi.Repository.Specification.Abstractions.Specification`, `BaseSpecification`, `PersonRow`, `Person`?**
  _High betweenness centrality (0.203) - this node is a cross-community bridge._
- **Why does `Axi.Repository.Specification.Abstractions.Specification` connect `Axi.Repository.Specification.Abstractions.Specification` to `BaseSpecification`, `ISpecification`, `Person`?**
  _High betweenness centrality (0.157) - this node is a cross-community bridge._
- **Why does `BaseSpecification` connect `BaseSpecification` to `ISpecification`, `PersonRow`, `Person`?**
  _High betweenness centrality (0.156) - this node is a cross-community bridge._
- **Are the 7 inferred relationships involving `PersonRow` (e.g. with `.SeedPeopleAsync()` and `.SaveChanges_PersistsChanges()`) actually correct?**
  _`PersonRow` has 7 INFERRED edges - model-reasoned connections that need verification._
- **What connects `IsCriteriaEvaluator`, `Criteria`, `IncludePaths` to the rest of the system?**
  _93 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Axi.Repository.Specification.Abstractions.Specification` be split into smaller, more focused modules?**
  _Cohesion score 0.05541346973572037 - nodes in this community are weakly interconnected._
- **Should `.CreateContext` be split into smaller, more focused modules?**
  _Cohesion score 0.08888888888888889 - nodes in this community are weakly interconnected._