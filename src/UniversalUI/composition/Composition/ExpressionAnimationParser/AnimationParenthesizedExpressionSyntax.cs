// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Composition;

internal class AnimationParenthesizedExpressionSyntax : AnimationExpressionSyntax
{
	private readonly AnimationExpressionSyntax _expression;

	public AnimationParenthesizedExpressionSyntax(AnimationExpressionSyntax expression)
	{
		_expression = expression;
	}

	public override object Evaluate(ExpressionAnimation expressionAnimation)
		=> _expression.Evaluate(expressionAnimation);
}
