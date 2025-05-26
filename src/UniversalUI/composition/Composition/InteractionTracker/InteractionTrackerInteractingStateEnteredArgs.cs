// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Composition.Interactions;

public partial class InteractionTrackerInteractingStateEnteredArgs
{
	internal InteractionTrackerInteractingStateEnteredArgs(int requestId, bool isFromBinding)
	{
		RequestId = requestId;
		IsFromBinding = isFromBinding;
	}

	public int RequestId { get; }

	public bool IsFromBinding { get; }
}
