// This file is copied, with modifications, from the Uno project

using System;
using System.Globalization;
using System.Numerics;

namespace UniversalUI.Composition;

internal sealed class ClampFloatFloatFloatFunctionSpecification : IAnimationFunctionSpecification
{
	private ClampFloatFloatFloatFunctionSpecification()
	{
	}

	public static ClampFloatFloatFloatFunctionSpecification Instance { get; } = new();

	public int ParametersLength => 3;

	public string MethodName => "Clamp";

	public string? ClassName => null;

	public object Evaluate(params object[] parameters)
		=> Math.Clamp(
			Convert.ToSingle(parameters[0], CultureInfo.InvariantCulture),
			Convert.ToSingle(parameters[1], CultureInfo.InvariantCulture),
			Convert.ToSingle(parameters[2], CultureInfo.InvariantCulture));
}
