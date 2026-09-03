# Graph Report - Axi.Repository  (2026-09-04)

## Corpus Check
- cluster-only mode — file stats not available

## Summary
- 502 nodes · 959 edges · 18 communities (15 shown, 3 thin omitted)
- Extraction: 88% EXTRACTED · 12% INFERRED · 0% AMBIGUOUS · INFERRED: 116 edges (avg confidence: 0.84)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `2772e132`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- .CreateContext
- BaseSpecification
- Axi.Repository.Models
- Axi.Repository.Specification.Abstractions.Specification
- ISpecification
- PageRequest
- Axi.Repository.Specification.Test.Specification
- PersonRow
- Axi.Repository.Specification.Test.csproj
- Person
- WriteRepositoryBase
- UnitOfWorkBase
- Axi.Repository Core Package
- .ListAsync
- ReadRepositoryBase
- buildNuget.sh
- NoTrackingEvaluator
- Split Queries

## God Nodes (most connected - your core abstractions)
1. `BaseSpecification` - 39 edges
2. `ISpecification` - 30 edges
3. `Axi.Repository.Specification.Abstractions.Specification` - 27 edges
4. `PersonRow` - 20 edges
5. `Axi.Repository.Models` - 16 edges
6. `Axi.Repository.Specification.Abstractions.Evaluators` - 12 edges
7. `PageRequest` - 12 edges
8. `Axi.Repository.Abstractions.Repository` - 11 edges
9. `Axi.Repository.Repository` - 11 edges
10. `ReadRepositoryBase` - 11 edges

## Surprising Connections (you probably didn't know these)
- `BaseSpecification` --inherits--> `AgeDescSpec`  [EXTRACTED]
  Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs → Tests/Axi.Repository.Specification.Test/Specification/AgeDescSpec.cs
- `BaseSpecification` --inherits--> `AgeSpec`  [EXTRACTED]
  Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs → Tests/Axi.Repository.Specification.Test/Specification/AgeSpec.cs
- `BaseSpecification` --inherits--> `BothOrderingsSpec`  [EXTRACTED]
  Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs → Tests/Axi.Repository.Specification.Test/Specification/BothOrderingsSpec.cs
- `BaseSpecification` --inherits--> `EmptySpec`  [EXTRACTED]
  Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs → Tests/Axi.Repository.Specification.Test/Specification/EmptySpec.cs
- `BaseSpecification` --inherits--> `OrderingSpec`  [EXTRACTED]
  Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs → Tests/Axi.Repository.Specification.Test/Specification/OrderingSpec.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Paginated Repository Query** — readme_ibasereadrepository, readme_pagerequest, readme_pagedresult [EXTRACTED 1.00]
- **Repository Specification Query Flow** — readme_basespecification, readme_specificationreadrepository, readme_ispecification [EXTRACTED 1.00]

## Communities (18 total, 3 thin omitted)

### Community 0 - ".CreateContext"
Cohesion: 0.10
Nodes (31): ArgumentOutOfRangeException, DbContext, CursorRequest, TestDb, DbContextOptions, Task, TestDbContext, People (+23 more)

### Community 1 - "BaseSpecification"
Cohesion: 0.07
Nodes (26): ExpressionStarter, IncludeChain, InvalidOperationException, AsNoTracking, AsSplitQuery, Criteria, IncludePaths, OrderBy (+18 more)

### Community 2 - "Axi.Repository.Models"
Cohesion: 0.09
Nodes (16): Axi.Repository.Test.Models, Axi.Repository.Test, Axi.Repository.Repository, Axi.Repository.Abstractions.Repository, Axi.Repository.Models, Axi.Repository.Specification.Repository, Axi.Repository.Test.Repository, Axi.Repository.Specification.Abstractions.Repository (+8 more)

### Community 3 - "Axi.Repository.Specification.Abstractions.Specification"
Cohesion: 0.07
Nodes (27): Axi.Repository.Specification.Evaluators, Axi.Repository.Specification.Abstractions.Specification, Axi.Repository.Specification.Evaluators.InMemory, Axi.Repository.Specification.Abstractions.Evaluators, IEvaluator, IsCriteriaEvaluator, IInMemoryEvaluator, IEnumerable (+19 more)

### Community 4 - "ISpecification"
Cohesion: 0.07
Nodes (27): IQueryable, CancellationToken, List, Task, ISpecification, AsNoTracking, AsSplitQuery, Criteria (+19 more)

### Community 5 - "PageRequest"
Cohesion: 0.07
Nodes (28): CancellationToken, Expression, Func, Task, PagedResult, TotalPages, IReadOnlyList, PageRequest (+20 more)

### Community 6 - "Axi.Repository.Specification.Test.Specification"
Cohesion: 0.10
Nodes (18): Axi.Repository.Specification.Specification, Axi.Repository.Specification.Test.Specification, IInMemorySpecificationEvaluator, IEnumerable, InMemorySpecificationEvaluator, IEnumerable, BothOrderingsSpec, Person (+10 more)

### Community 7 - "PersonRow"
Cohesion: 0.14
Nodes (19): Axi.Repository.Specification.Test.Repository, Axi.Repository.Specification.Test.Models, Axi.Repository.Specification.Test.Data, TestDbContext, People, DbContextOptions, DbSet, PersonRow (+11 more)

### Community 8 - "Axi.Repository.Specification.Test.csproj"
Cohesion: 0.08
Nodes (24): AutoFixture, AutoFixture.Xunit2, LinqKit.Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Relational, Moq, net10.0, Microsoft.NET.Sdk (+16 more)

### Community 9 - "Person"
Cohesion: 0.08
Nodes (23): Axi.Repository.Specification.Test, Address, City, Street, City, Name, Order, Id (+15 more)

### Community 10 - "WriteRepositoryBase"
Cohesion: 0.15
Nodes (8): IWriteRepository, CancellationToken, IEnumerable, Task, WriteRepositoryBase, CancellationToken, IEnumerable, Task

### Community 11 - "UnitOfWorkBase"
Cohesion: 0.12
Nodes (13): IAsyncDisposable, IDisposable, IUnitOfWork, CancellationToken, Task, UnitOfWorkBase, CancellationToken, Task (+5 more)

### Community 12 - "Axi.Repository Core Package"
Cohesion: 0.11
Nodes (22): Axi.Repository Core Package, Axi.Repository Library, Axi.Repository.Specification Package, BaseSpecification<T>, CriteriaEvaluator, Eager Loading, Entity Framework Core, IBaseReadRepository<T> (+14 more)

### Community 13 - ".ListAsync"
Cohesion: 0.13
Nodes (13): CancellationToken, Expression, Func, Task, CursorResult, IReadOnlyList, CursorReadRepositoryBase, CancellationToken (+5 more)

### Community 14 - "ReadRepositoryBase"
Cohesion: 0.47
Nodes (6): ReadRepositoryBase, DbContext, CancellationToken, Expression, Func, Task

## Knowledge Gaps
- **91 isolated node(s):** `IsCriteriaEvaluator`, `Criteria`, `IncludePaths`, `OrderBy`, `OrderByDescending` (+86 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **3 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `ISpecification` connect `ISpecification` to `BaseSpecification`, `Axi.Repository.Specification.Abstractions.Specification`, `Axi.Repository.Specification.Test.Specification`?**
  _High betweenness centrality (0.200) - this node is a cross-community bridge._
- **Why does `BaseSpecification` connect `BaseSpecification` to `Axi.Repository.Specification.Abstractions.Specification`, `ISpecification`, `Axi.Repository.Specification.Test.Specification`, `PersonRow`?**
  _High betweenness centrality (0.157) - this node is a cross-community bridge._
- **Why does `Axi.Repository.Specification.Abstractions.Specification` connect `Axi.Repository.Specification.Abstractions.Specification` to `BaseSpecification`, `Axi.Repository.Models`, `Axi.Repository.Specification.Test.Specification`, `PersonRow`?**
  _High betweenness centrality (0.149) - this node is a cross-community bridge._
- **Are the 7 inferred relationships involving `PersonRow` (e.g. with `.SeedPeopleAsync()` and `.SaveChanges_PersistsChanges()`) actually correct?**
  _`PersonRow` has 7 INFERRED edges - model-reasoned connections that need verification._
- **What connects `IsCriteriaEvaluator`, `Criteria`, `IncludePaths` to the rest of the system?**
  _91 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `.CreateContext` be split into smaller, more focused modules?**
  _Cohesion score 0.09577677224736049 - nodes in this community are weakly interconnected._
- **Should `BaseSpecification` be split into smaller, more focused modules?**
  _Cohesion score 0.07164404223227752 - nodes in this community are weakly interconnected._