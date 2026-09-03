using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

public abstract partial class BaseSpecification<T>
{
    /// <summary>
    /// Adds a reference navigation path for eager loading.
    /// </summary>
    /// <typeparam name="TNext">The related entity type.</typeparam>
    /// <param name="nav">An expression selecting the navigation property.</param>
    /// <returns>An include chain that can be extended with nested navigations.</returns>
    /// <exception cref="InvalidOperationException"><paramref name="nav"/> is not a supported member-access expression.</exception>
    protected IncludeChain<TNext> Include<TNext>(Expression<Func<T, TNext>> nav)
        => AddIncludeChain<TNext>(MemberPath.Of(nav.Body));

    /// <summary>
    /// Adds a collection navigation path for eager loading.
    /// </summary>
    /// <typeparam name="TElement">The collection element type.</typeparam>
    /// <param name="nav">An expression selecting the collection navigation property.</param>
    /// <returns>An include chain that can be extended with nested navigations.</returns>
    /// <exception cref="InvalidOperationException"><paramref name="nav"/> is not a supported member-access expression.</exception>
    protected IncludeChain<TElement> IncludeMany<TElement>(Expression<Func<T, IEnumerable<TElement>>> nav)
        => AddIncludeChain<TElement>(MemberPath.Of(nav.Body));

    private void UpdateIncludePath(int index, string newPath) => _includePaths[index] = newPath;

    private IncludeChain<TNext> AddIncludeChain<TNext>(string path)
    {
        _includePaths.Add(path);
        var index = _includePaths.Count - 1;
        return new IncludeChain<TNext>(this, index, path);
    }

    /// <summary>
    /// Builds a nested eager-loading path.
    /// </summary>
    /// <typeparam name="TCurrent">The entity type at the current position in the path.</typeparam>
    public sealed class IncludeChain<TCurrent>
    {
        private readonly int _index;

        private readonly BaseSpecification<T> _spec;

        private string _path;

        internal IncludeChain(BaseSpecification<T> spec, int index, string path)
        {
            _spec = spec;
            _index = index;
            _path = path;
        }

        /// <summary>
        /// Adds a reference navigation to the current include path.
        /// </summary>
        /// <typeparam name="TNext">The related entity type.</typeparam>
        /// <param name="nav">An expression selecting the navigation property.</param>
        /// <returns>An include chain positioned at the added navigation.</returns>
        /// <exception cref="InvalidOperationException"><paramref name="nav"/> is not a supported member-access expression.</exception>
        public IncludeChain<TNext> Then<TNext>(Expression<Func<TCurrent, TNext>> nav)
        {
            _path = $"{_path}.{MemberPath.Of(nav.Body)}";
            _spec.UpdateIncludePath(_index, _path);
            return new IncludeChain<TNext>(_spec, _index, _path);
        }

        /// <summary>
        /// Adds a collection navigation to the current include path.
        /// </summary>
        /// <typeparam name="TNext">The collection element type.</typeparam>
        /// <param name="nav">An expression selecting the collection navigation property.</param>
        /// <returns>An include chain positioned at the added navigation.</returns>
        /// <exception cref="InvalidOperationException"><paramref name="nav"/> is not a supported member-access expression.</exception>
        public IncludeChain<TNext> ThenMany<TNext>(Expression<Func<TCurrent, IEnumerable<TNext>>> nav)
        {
            _path = $"{_path}.{MemberPath.Of(nav.Body)}";
            _spec.UpdateIncludePath(_index, _path);
            return new IncludeChain<TNext>(_spec, _index, _path);
        }
    }
}
