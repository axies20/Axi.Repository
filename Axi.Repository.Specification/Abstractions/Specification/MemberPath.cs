using System.Linq.Expressions;

namespace Axi.Repository.Specification.Abstractions.Specification;

/// <summary>
/// Extracts dot-separated member access paths from expressions.
/// </summary>
internal static class MemberPath
{
    /// <summary>
    /// Extracts member path from expression.
    /// </summary>
    /// <param name="expr">Member access expression.</param>
    /// <returns>Dot-separated path string.</returns>
    /// <exception cref="InvalidOperationException">Invalid member access expression.</exception>
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