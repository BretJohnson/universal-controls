// This file is copied, with modifications, from the Uno project

#nullable disable

namespace UniversalUI.Composition;

internal class AnimationNumericExpressionSyntax : AnimationExpressionSyntax
{
	private readonly ExpressionAnimationToken _number;

	public AnimationNumericExpressionSyntax(ExpressionAnimationToken number)
	{
		_number = number;
	}

	public override object Evaluate(ExpressionAnimation expressionAnimation)
	{
		return _number.Value;
	}
}
