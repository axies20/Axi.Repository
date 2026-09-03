# Graph Report - Axi.Repository  (2026-09-04)

## Corpus Check
- cluster-only mode — file stats not available

## Summary
- 529 nodes · 941 edges · 35 communities (25 shown, 10 thin omitted)
- Extraction: 88% EXTRACTED · 12% INFERRED · 0% AMBIGUOUS · INFERRED: 110 edges (avg confidence: 0.84)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `2772e132`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- Axi.Repository.Specification.Test.Specification
- BaseSpecification
- .CreateContext
- .ListAsync
- Axi.Repository.Specification.Test.csproj
- IWriteRepository
- UnitOfWorkBase
- ISpecification<T>
- Person
- Axi.Repository.Models
- .ListAsync
- Axi.Repository.Specification.Abstractions.Evaluators
- .ListAsync
- ISpecification
- List
- IReadRepository
- .ListAsync
- IUnitOfWork
- Axi.Repository.Specification.Abstractions.Specification
- SplitQueryEvaluator
- IEvaluator
- IReadOnlyList
- CursorReadRepositoryBase<T, TCursor, TDbContext>
- Offset Pagination
- Expression
- CriteriaEvaluator
- IncludePathsEvaluator
- Axi.Repository.Specification.Evaluators
- OrderingEvaluator
- buildNuget.sh
- IUnitOfWork
- IWriteRepository<T>
- Func
- PagedResult
- PageRequest

## God Nodes (most connected - your core abstractions)
1. `BaseSpecification` - 39 edges
2. `ISpecification` - 22 edges
3. `Axi.Repository.Specification.Abstractions.Specification` - 22 edges
4. `PersonRow` - 20 edges
5. `Axi.Repository.Models` - 13 edges
6. `Axi.Repository.Specification.Abstractions.Evaluators` - 12 edges
7. `PersonCursorRepository` - 11 edges
8. `PersonWriteRepository` - 11 edges
9. `PersonRow` - 11 edges
10. `Axi.Repository.Specification.Test.Specification` - 11 edges

## Surprising Connections (you probably didn't know these)
- `BothOrderingsSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/BothOrderingsSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `EmptySpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/EmptySpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `OrderingSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/OrderingSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `PersonCriteriaSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/PersonCriteriaSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs
- `PersonIncludeSpec` --inherits--> `BaseSpecification`  [EXTRACTED]
  Tests/Axi.Repository.Specification.Test/Specification/PersonIncludeSpec.cs → Source/Axi.Repository.Specification/Abstractions/Specification/BaseSpecification.Criteria.cs

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Query Evaluator Suite** — readme_criteriaevaluator, readme_includepathsevaluator, readme_orderingevaluator, readme_notrackingevaluator, readme_splitqueryevaluator [EXTRACTED 1.00]

## Communities (35 total, 10 thin omitted)

### Community 0 - "Axi.Repository.Specification.Test.Specification"
Cohesion: 0.07
Nodes (25): Axi.Repository.Specification.Specification, Axi.Repository.Specification.Test.Specification, Axi.Repository.Specification.Test, InvalidOperationException, IInMemorySpecificationEvaluator, IEnumerable, ISpecification, InMemorySpecificationEvaluator (+17 more)

### Community 1 - "BaseSpecification"
Cohesion: 0.09
Nodes (23): ExpressionStarter, IncludeChain, AsNoTracking, AsSplitQuery, Criteria, IncludePaths, OrderBy, OrderByDescending (+15 more)

### Community 2 - ".CreateContext"
Cohesion: 0.07
Nodes (38): ArgumentOutOfRangeException, IWriteRepository, CursorRequest, WriteRepositoryBase, CancellationToken, IEnumerable, Task, TestDb (+30 more)

### Community 3 - ".ListAsync"
Cohesion: 0.09
Nodes (30): Axi.Repository.Specification.Test.Repository, Axi.Repository.Specification.Test.Models, Axi.Repository.Specification.Test.Data, DbContext, ISpecificationReadRepository, List, PageRequest, SpecificationReadRepositoryBase (+22 more)

### Community 4 - "Axi.Repository.Specification.Test.csproj"
Cohesion: 0.12
Nodes (18): AutoFixture, AutoFixture.Xunit2, LinqKit.Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore, Microsoft.EntityFrameworkCore.Relational, Moq, net10.0, Microsoft.NET.Sdk (+10 more)

### Community 5 - "IWriteRepository"
Cohesion: 0.24
Nodes (4): IWriteRepository, CancellationToken, IEnumerable, Task

### Community 6 - "UnitOfWorkBase"
Cohesion: 0.16
Nodes (9): IUnitOfWork, UnitOfWorkBase, CancellationToken, Task, PersonUnitOfWork, UnitOfWorkBaseTests, Fact, Task (+1 more)

### Community 7 - "ISpecification<T>"
Cohesion: 0.09
Nodes (23): ActiveProductsSpec, Axi.Repository, Axi.Repository.Specification, BaseSpecification<T>, CriteriaEvaluator, .NET 10.0, Entity Framework Core, In-Memory Specification Evaluator (+15 more)

### Community 8 - "Person"
Cohesion: 0.09
Nodes (20): Address, City, Street, Order, Id, Lines, Total, List (+12 more)

### Community 9 - "Axi.Repository.Models"
Cohesion: 0.07
Nodes (21): Axi.Repository.Test.Models, Axi.Repository.Test, Axi.Repository.Repository, Axi.Repository.Abstractions.Repository, Axi.Repository.Models, Axi.Repository.Specification.Repository, Axi.Repository.Test.Repository, IReadOnlyList (+13 more)

### Community 10 - ".ListAsync"
Cohesion: 0.10
Nodes (20): Expression, Func, IPagedReadRepository, CancellationToken, Expression, Func, PagedResult, PageRequest (+12 more)

### Community 11 - "Axi.Repository.Specification.Abstractions.Evaluators"
Cohesion: 0.17
Nodes (10): Axi.Repository.Specification.Evaluators.InMemory, Axi.Repository.Specification.Abstractions.Evaluators, IInMemoryEvaluator, IEnumerable, ISpecification, InMemoryCriteriaEvaluator, Instance, InMemoryOrderingEvaluator (+2 more)

### Community 12 - ".ListAsync"
Cohesion: 0.11
Nodes (16): CursorRequest, CursorResult, ICursorReadRepository, CancellationToken, Expression, Func, Task, CursorResult (+8 more)

### Community 13 - "ISpecification"
Cohesion: 0.17
Nodes (11): ISpecification, AsNoTracking, AsSplitQuery, Criteria, IncludePaths, OrderBy, OrderByDescending, Expression (+3 more)

### Community 15 - "IReadRepository"
Cohesion: 0.47
Nodes (5): IReadRepository, CancellationToken, Expression, Func, Task

### Community 16 - ".ListAsync"
Cohesion: 0.29
Nodes (7): IReadRepository, ISpecificationReadRepository, CancellationToken, List, PagedResult, PageRequest, Task

### Community 17 - "IUnitOfWork"
Cohesion: 0.25
Nodes (5): IAsyncDisposable, IDisposable, IUnitOfWork, CancellationToken, Task

### Community 19 - "SplitQueryEvaluator"
Cohesion: 0.33
Nodes (4): SplitQueryEvaluator, Instance, IsCriteriaEvaluator, IQueryable

### Community 20 - "IEvaluator"
Cohesion: 0.33
Nodes (4): IEvaluator, IsCriteriaEvaluator, IQueryable, ISpecification

### Community 22 - "CursorReadRepositoryBase<T, TCursor, TDbContext>"
Cohesion: 0.40
Nodes (5): Cursor Pagination, CursorReadRepositoryBase<T, TCursor, TDbContext>, CursorRequest<TCursor>, CursorResult<T, TCursor>, ICursorReadRepository<T, TCursor>

### Community 23 - "Offset Pagination"
Cohesion: 0.60
Nodes (5): IPagedReadRepository<T>, Offset Pagination, PagedReadRepositoryBase<T, TDbContext>, PagedResult<T>, PageRequest

### Community 25 - "CriteriaEvaluator"
Cohesion: 0.33
Nodes (4): CriteriaEvaluator, Instance, IsCriteriaEvaluator, IQueryable

### Community 26 - "IncludePathsEvaluator"
Cohesion: 0.33
Nodes (4): IncludePathsEvaluator, Instance, IsCriteriaEvaluator, IQueryable

### Community 27 - "Axi.Repository.Specification.Evaluators"
Cohesion: 0.29
Nodes (5): Axi.Repository.Specification.Evaluators, NoTrackingEvaluator, Instance, IsCriteriaEvaluator, IQueryable

### Community 28 - "OrderingEvaluator"
Cohesion: 0.33
Nodes (4): OrderingEvaluator, Instance, IsCriteriaEvaluator, IQueryable

## Knowledge Gaps
- **90 isolated node(s):** `Axi.Repository.Specification.Abstractions.Repository`, `AsNoTracking`, `AsSplitQuery`, `Criteria`, `IncludePaths` (+85 more)
  These have ≤1 connection - possible missing edges or undocumented components.
- **10 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `BaseSpecification` connect `BaseSpecification` to `Axi.Repository.Specification.Test.Specification`, `Axi.Repository.Specification.Abstractions.Specification`, `.ListAsync`, `ISpecification`?**
  _High betweenness centrality (0.178) - this node is a cross-community bridge._
- **Why does `ISpecification` connect `ISpecification` to `Axi.Repository.Specification.Test.Specification`, `BaseSpecification`, `Axi.Repository.Specification.Abstractions.Evaluators`, `.ListAsync`, `Axi.Repository.Specification.Abstractions.Specification`, `SplitQueryEvaluator`, `CriteriaEvaluator`, `IncludePathsEvaluator`, `Axi.Repository.Specification.Evaluators`, `OrderingEvaluator`?**
  _High betweenness centrality (0.119) - this node is a cross-community bridge._
- **Why does `Axi.Repository.Abstractions.Repository` connect `Axi.Repository.Models` to `.ListAsync`, `.ListAsync`, `IReadRepository`, `IUnitOfWork`, `Axi.Repository.Specification.Abstractions.Specification`?**
  _High betweenness centrality (0.112) - this node is a cross-community bridge._
- **Are the 7 inferred relationships involving `PersonRow` (e.g. with `.SeedPeopleAsync()` and `.SaveChanges_PersistsChanges()`) actually correct?**
  _`PersonRow` has 7 INFERRED edges - model-reasoned connections that need verification._
- **What connects `Axi.Repository.Specification.Abstractions.Repository`, `AsNoTracking`, `AsSplitQuery` to the rest of the system?**
  _90 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `Axi.Repository.Specification.Test.Specification` be split into smaller, more focused modules?**
  _Cohesion score 0.0653061224489796 - nodes in this community are weakly interconnected._
- **Should `BaseSpecification` be split into smaller, more focused modules?**
  _Cohesion score 0.08562367864693446 - nodes in this community are weakly interconnected._