// This file is copied, with modifications, from the Uno project

#nullable disable

using System;
using System.Numerics;

using static UniversalUI.Composition.SubPropertyHelpers;

namespace UniversalUI.Composition;

internal class AnimationMemberAccessExpressionSyntax : AnimationExpressionSyntax
{
	public AnimationMemberAccessExpressionSyntax(AnimationExpressionSyntax expression, ExpressionAnimationToken identifier)
	{
		Expression = expression;
		Identifier = identifier;
	}

	public AnimationExpressionSyntax Expression { get; }
	public ExpressionAnimationToken Identifier { get; }

	public override object Evaluate(ExpressionAnimation expressionAnimation)
	{
		var leftValue = Expression.Evaluate(expressionAnimation);
		var propertyName = (string)Identifier.Value;
		if (leftValue is CompositionObject leftCompositionObject)
		{
			return leftCompositionObject.GetAnimatableProperty(propertyName, string.Empty);
		}
		else
		{
			return GetSubProperty(propertyName, leftValue);
		}

		throw new ArgumentException($"Cannot find evaluate property '{propertyName}' on object of type '{leftValue?.GetType()}'.");
	}
}
