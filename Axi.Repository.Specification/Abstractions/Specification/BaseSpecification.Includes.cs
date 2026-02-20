using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Represents a base class for defining reusable and composable query specifications
/// within the context of a repository pattern.
/// </summary>
/// <typeparam name="T">The entity type for which the specification is created.</typeparam>
/// <remarks>
/// The <see cref="BaseSpecification{T}"/> class enables developers to define sophisticated
/// query rules, including predicates, include paths for eager loading, and ordering.
/// It also supports conditional query logic and chaining for advanced scenarios.
/// </remarks>
public abstract partial class BaseSpecification<T>
{
    /// <summary>
    /// Configures an include path for a related entity to be eagerly loaded as part of the query.
    /// </summary>
    /// <typeparam name="TNext">The type of the related entity being included.</typeparam>
    /// <param name="nav">An expression that navigates to the related entity from the current entity.</param>
    /// <returns>An <see cref="IncludeChain{TNext}"/> that allows chaining further include paths.</returns>
    protected IncludeChain<TNext> Include<TNext>(Expression<Func<T, TNext>> nav)
        => AddIncludeChain<TNext>(MemberPath.Of(nav.Body));

    /// <summary>
    /// Configures a collection navigation property as part of an inclusion chain, allowing
    /// additional related entities to be eager loaded in the query.
    /// </summary>
    /// <typeparam name="TElement">The type of the elements in the collection being included.</typeparam>
    /// <param name="nav">
    /// An expression representing the navigation property for the collection to include.
    /// The property must be a collection-type navigation property on the current entity.
    /// </param>
    /// <returns>
    /// An instance of <see cref="IncludeChain{TCurrent}"/> that can be used to chain further include configurations
    /// for the related entities starting from the specified collection.
    /// </returns>
    protected IncludeChain<TElement> IncludeMany<TElement>(Expression<Func<T, IEnumerable<TElement>>> nav)
        => AddIncludeChain<TElement>(MemberPath.Of(nav.Body));

    /// <summary>
    /// Updates the include path at the specified index with a new path.
    /// This method is used internally by the specification to change the path of an
    /// include, enabling modification of the query composition for related entities.
    /// </summary>
    /// <param name="index">The index of the include path to update, referring to its position in the internal include paths collection.</param>
    /// <param name="newPath">The new path to replace the existing path at the specified index.</param>
    private void UpdateIncludePath(int index, string newPath) => _includePaths[index] = newPath;

    /// <summary>
    /// Adds a new include chain to the specification's include paths for the specified navigation property.
    /// This method facilitates eager loading of related entities by adding the path of the navigation property
    /// to the internal collection of include paths.
    /// </summary>
    /// <typeparam name="TNext">The type of the related entity to include.</typeparam>
    /// <param name="path">The navigation property path as a string.</param>
    /// <returns>
    /// An <see cref="IncludeChain{TNext}"/> instance that allows for chaining additional navigation properties
    /// to include in the specification.
    /// </returns>
    private IncludeChain<TNext> AddIncludeChain<TNext>(string path)
    {
        _includePaths.Add(path);
        var index = _includePaths.Count - 1;
        return new IncludeChain<TNext>(this, index, path);
    }

    /// <summary>
    /// Represents a chainable mechanism to specify navigation properties for inclusion in a query.
    /// Allows fluent chaining of navigational properties to configure nested includes in specifications.
    /// </summary>
    /// <typeparam name="TCurrent">The current type in the include chain.</typeparam>
    public sealed class IncludeChain<TCurrent>
    {
        /// <summary>
        /// Represents the index within the internal collection of include paths
        /// that corresponds to the current navigation chain in a specification.
        /// </summary>
        /// <remarks>
        /// The variable is used to track and update the specific include path
        /// associated with the current <see cref="IncludeChain{T}"/> instance.
        /// </remarks>
        private readonly int _index;

        /// <summary>
        /// Represents a variable that holds a reference to the parent specification in the context
        /// of building include chains for eager loading in a repository query specification.
        /// </summary>
        /// <remarks>
        /// This variable is primarily used internally to manage and update include paths during the
        /// chaining of `Include` methods in an instance of <see cref="BaseSpecification{T}.IncludeChain{TCurrent}"/>.
        /// It ensures that modifications to the include path are propagated to the associated specification.
        /// </remarks>
        private readonly BaseSpecification<T> _spec;

        /// <summary>
        /// Represents the navigation path for including related entities in a query.
        /// The path is dynamically built using expressions provided in the include chain,
        /// representing the relationships between entities.
        /// </summary>
        private string _path;

        /// <summary>
        /// Represents a chain used to build and compose include paths for navigation properties
        /// in query specifications. The chain allows defining navigation paths for eager loading related data.
        /// </summary>
        /// <typeparam name="TCurrent">The current entity type at this point in the include chain.</typeparam>
        /// <remarks>
        /// This class facilitates chaining navigation expressions to build complex include paths for specifying
        /// related data entities to load as part of a query. It supports both single relationships and collections.
        /// </remarks>
        internal IncludeChain(BaseSpecification<T> spec, int index, string path)
        {
            _spec = spec;
            _index = index;
            _path = path;
        }

        /// <summary>
        /// Specifies an additional level of navigation for including related entities in a query.
        /// It appends the specified property or navigation property of the current entity type to the include path.
        /// This allows chaining multiple levels of includes in a type-safe manner.
        /// </summary>
        /// <typeparam name="TNext">The type of the related entity or property to be included.</typeparam>
        /// <param name="nav">An expression that specifies the related property or navigation property to include.</param>
        /// <returns>An <c>IncludeChain</c> instance for the specified navigation property, enabling further chaining of include paths.</returns>
        public IncludeChain<TNext> Then<TNext>(Expression<Func<TCurrent, TNext>> nav)
        {
            _path = $"{_path}.{MemberPath.Of(nav.Body)}";
            _spec.UpdateIncludePath(_index, _path);
            return new IncludeChain<TNext>(_spec, _index, _path);
        }

        /// <summary>
        /// Appends a collection navigation property to the current include chain, forming a path for eager loading
        /// related entities. The method enables chaining of multiple collection includes.
        /// </summary>
        /// <typeparam name="TNext">The type of the elements in the collection being included.</typeparam>
        /// <param name="nav">An expression that specifies the collection navigation property to include.</param>
        /// <returns>An <see cref="IncludeChain{TNext}"/> instance representing the updated include chain.</returns>
        public IncludeChain<TNext> ThenMany<TNext>(Expression<Func<TCurrent, IEnumerable<TNext>>> nav)
        {
            _path = $"{_path}.{MemberPath.Of(nav.Body)}";
            _spec.UpdateIncludePath(_index, _path);
            return new IncludeChain<TNext>(_spec, _index, _path);
        }
    }
}