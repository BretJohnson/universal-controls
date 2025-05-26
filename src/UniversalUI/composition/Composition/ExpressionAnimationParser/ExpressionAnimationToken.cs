// This file is copied, with modifications, from the Uno project

#nullable enable

namespace UniversalUI.Composition;

internal readonly struct ExpressionAnimationToken
{
	public ExpressionAnimationTokenKind Kind { get; }

	public object? Value { get; }

	public ExpressionAnimationToken(ExpressionAnimationTokenKind kind, object? value)
	{
		Kind = kind;
		Value = value;
	}
}
