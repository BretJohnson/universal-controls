// This file is copied, with modifications, from the Uno project

using System;
using System.Numerics;

namespace UniversalUI.Composition.Interactions;

internal abstract class InteractionTrackerState : IDisposable
{
	private protected InteractionTracker _interactionTracker;
	private protected bool _disposed;

	public InteractionTrackerState(InteractionTracker interactionTracker)
	{
		_interactionTracker = interactionTracker;
        // TODO: Handler this when needed
		//NativeDispatcher.Main.Enqueue(() => EnterState(interactionTracker.Owner));
	}

	protected abstract void EnterState(IInteractionTrackerOwner? owner);
	internal abstract void StartUserManipulation();
	internal abstract void CompleteUserManipulation(Vector3 linearVelocity);
	internal abstract void ReceiveManipulationDelta(Point translationDelta);
	internal abstract void ReceiveInertiaStarting(Point linearVelocity);
	internal abstract void ReceivePointerWheel(int delta, bool isHorizontal);
	internal abstract void TryUpdatePositionWithAdditionalVelocity(Vector3 velocityInPixelsPerSecond, int requestId);
	internal abstract void TryUpdatePosition(Vector3 value, InteractionTrackerClampingOption option, int requestId);
	public virtual void Dispose() => _disposed = true;
}
