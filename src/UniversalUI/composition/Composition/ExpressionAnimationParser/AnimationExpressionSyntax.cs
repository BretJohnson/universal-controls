// This file is copied, with modifications, from the Uno project

using System;

namespace UniversalUI.Composition;

internal abstract class AnimationExpressionSyntax : IDisposable
{
	public virtual void Dispose() { }
	public abstract object Evaluate(ExpressionAnimation expressionAnimation);
}
