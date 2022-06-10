using System;
using Anchorage.CodeAnalysis.Binding;
using Anchorage.CodeAnalysis.Syntax;

namespace Anchorage.CodeAnalysis
{
    public sealed class Evaluator
    {
        private readonly BoundExpression _root;

        public Evaluator(BoundExpression root)
        {
            _root = root;
        }

        public int Evaluate()
        {
            return EvaluateExpression(_root);
        }

        private int EvaluateExpression(BoundExpression node)
        {
            if (node is BoundLiteralExpression n)
                return (int)n.Value;

            if (node is BoundUnaryExpression u)
            {
                var operand = EvaluateExpression(u.Operand);

                if (u.OperatorKind == BoundUnaryOperatorKind.Identity)
                    return operand;
                else if (u.OperatorKind == BoundUnaryOperatorKind.Negation)
                    return -operand;
                else
                    throw new Exception($"Unexpected unary operator {u.OperatorKind}.");
            }

            if (node is BinaryExpressionSyntax b)
            {
                var left = EvaluateExpression(b.Left);
                var right = EvaluateExpression(b.Right);

                if (b.OperatorToken.Kind == SyntaxKind.PlusToken)
                    return left + right;
                else if (b.OperatorToken.Kind == SyntaxKind.MinusToken)
                    return left - right;
                else if (b.OperatorToken.Kind == SyntaxKind.SlashToken)
                    return left / right;
                else if (b.OperatorToken.Kind == SyntaxKind.StarToken)
                    return left * right;
                else
                    throw new Exception($"Unexpected binary operator {b.OperatorToken.Kind}.");
            }

            if (node is ParenthesizedExpressionSyntax p)
                return EvaluateExpression(p.Expression);

            throw new Exception($"Unexpected node {node.Kind}.");
        }
    }
}
