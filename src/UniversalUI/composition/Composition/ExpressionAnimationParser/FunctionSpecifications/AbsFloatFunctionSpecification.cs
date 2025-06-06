// This file is copied, with modifications, from the Uno project

using System;
using System.Globalization;

namespace UniversalUI.Composition;

internal sealed class AbsFloatFunctionSpecification : IAnimationFunctionSpecification
{
	private AbsFloatFunctionSpecification()
	{
	}

	public static AbsFloatFunctionSpecification Instance { get; } = new();

	public int ParametersLength => 1;

	public string MethodName => "Abs";

	public string? ClassName => null;

	public object Evaluate(params object[] parameters)
		=> Math.Abs(Convert.ToSingle(parameters[0], CultureInfo.InvariantCulture));
}
