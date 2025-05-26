// This file is copied, with modifications, from the Uno project

using System.Numerics;

namespace UniversalUI.Composition.Interactions;

internal interface IInteractionTrackerInertiaHandler
{
	Vector3 InitialVelocity { get; }
	Vector3 FinalPosition { get; }
	Vector3 FinalModifiedPosition { get; }
	float FinalScale { get; }

	void Start();
	void Stop();
}
