// This file is copied, with modifications, from the Uno project

using System;
using System.Globalization;
using System.Numerics;

namespace UniversalUI.Composition;

internal sealed class Vector2FloatFloatFunctionSpecification : IAnimationFunctionSpecification
{
	private Vector2FloatFloatFunctionSpecification()
	{
	}

	public static Vector2FloatFloatFunctionSpecification Instance { get; } = new();

	public int ParametersLength => 2;

	public string MethodName => "Vector2";

	public string? ClassName => null;

	public object Evaluate(params object[] parameters)
		=> new Vector2(
			Convert.ToSingle(parameters[0], CultureInfo.InvariantCulture),
			Convert.ToSingle(parameters[1], CultureInfo.InvariantCulture));
}
