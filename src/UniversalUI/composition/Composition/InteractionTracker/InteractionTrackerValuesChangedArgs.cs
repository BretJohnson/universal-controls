// This file is copied, with modifications, from the Uno project

#nullable disable

using System.Numerics;

namespace UniversalUI.Composition.Interactions;

public sealed partial class InteractionTrackerValuesChangedArgs
{
	internal InteractionTrackerValuesChangedArgs(Vector3 position, float scale, int requestId)
	{
		Position = position;
		Scale = scale;
		RequestId = requestId;
	}

	public Vector3 Position { get; }

	public int RequestId { get; }

	public float Scale { get; }
}
