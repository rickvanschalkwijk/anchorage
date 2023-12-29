namespace Anchorage.CodeAnalysis.Syntax;

public enum SyntaxKind
{
    BadToken,
    EndOfFileToken,
    WhiteSpaceToken,
    NumberToken,
    PlusToken,
    MinusToken,
    StarToken,
    SlashToken,
    OpenParenthesisToken,
    CloseParenthesisToken,

    LiteralExpression,
    UnaryExpression,
    BinaryExpression,
    ParenthesizedExpression,
}