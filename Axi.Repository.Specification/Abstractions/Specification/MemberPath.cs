using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Provides functionality to extract and represent the dot-separated path of member access
/// from an expression tree.
/// </summary>
internal static class MemberPath
{
    /// <summary>
    /// Retrieves the member access path represented by the given expression.
    /// </summary>
    /// <param name="expr">
    /// The expression that represents member access. Typically, this is in the form of
    /// a lambda expression like x => x.Property or x => x.Property.SubProperty.
    /// </param>
    /// <returns>
    /// A string representing the full path of member access, with each member
    /// separated by a dot (e.g., "Property.SubProperty").
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the given expression does not represent a valid member access.
    /// </exception>
    public static string Of(Expression expr)
    {
        if (expr is UnaryExpression u && expr.NodeType == ExpressionType.Convert)
            expr = u.Operand;

        var parts = new Stack<string>();

        while (expr is MemberExpression m)
        {
            parts.Push(m.Member.Name);
            expr = m.Expression!;
        }

        if (parts.Count == 0)
            throw new InvalidOperationException("Expected member access like x => x.Prop or x => x.Prop.SubProp");

        return string.Join(".", parts);
    }
}