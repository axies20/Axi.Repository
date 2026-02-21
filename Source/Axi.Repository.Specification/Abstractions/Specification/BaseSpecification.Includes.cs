using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Base class for query specifications with include path support.
/// </summary>
/// <typeparam name="T">Entity type.</typeparam>
public abstract partial class BaseSpecification<T>
{
    /// <summary>
    /// Includes related entity for eager loading.
    /// </summary>
    /// <typeparam name="TNext">Related entity type.</typeparam>
    /// <param name="nav">Navigation expression.</param>
    /// <returns>Include a chain for further chaining.</returns>
    protected IncludeChain<TNext> Include<TNext>(Expression<Func<T, TNext>> nav)
        => AddIncludeChain<TNext>(MemberPath.Of(nav.Body));

    /// <summary>
    /// Includes collection navigation for eager loading.
    /// </summary>
    /// <typeparam name="TElement">Collection element type.</typeparam>
    /// <param name="nav">Navigation expression.</param>
    /// <returns>Include a chain for further chaining.</returns>
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
    /// Chainable mechanism for nested include paths.
    /// </summary>
    /// <typeparam name="TCurrent">Current type in chain.</typeparam>
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
        /// Chains next level of navigation.
        /// </summary>
        /// <typeparam name="TNext">Next entity type.</typeparam>
        /// <param name="nav">Navigation expression.</param>
        /// <returns>Include a chain for further chaining.</returns>
        public IncludeChain<TNext> Then<TNext>(Expression<Func<TCurrent, TNext>> nav)
        {
            _path = $"{_path}.{MemberPath.Of(nav.Body)}";
            _spec.UpdateIncludePath(_index, _path);
            return new IncludeChain<TNext>(_spec, _index, _path);
        }

        /// <summary>
        /// Chains collection navigation.
        /// </summary>
        /// <typeparam name="TNext">Collection element type.</typeparam>
        /// <param name="nav">Navigation expression.</param>
        /// <returns>Include a chain for further chaining.</returns>
        public IncludeChain<TNext> ThenMany<TNext>(Expression<Func<TCurrent, IEnumerable<TNext>>> nav)
        {
            _path = $"{_path}.{MemberPath.Of(nav.Body)}";
            _spec.UpdateIncludePath(_index, _path);
            return new IncludeChain<TNext>(_spec, _index, _path);
        }
    }
}