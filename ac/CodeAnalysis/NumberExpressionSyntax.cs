using System.Collections.Generic;

namespace Anchorage.CodeAnalysis
{
    sealed class NumberExpressionSyntax : ExpressionSyntax
    {
        public NumberExpressionSyntax(SyntaxToken numberToken)
        {
            NumberToken = numberToken;
        }

        public SyntaxToken NumberToken { get; }

        public override SyntaxKind Kind => SyntaxKind.NumberToken;

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return NumberToken;
        }
    }
}