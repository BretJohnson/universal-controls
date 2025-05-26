// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Composition.Interactions;

public partial class InteractionTrackerIdleStateEnteredArgs
{
	internal InteractionTrackerIdleStateEnteredArgs(int requestId, bool isFromBinding)
	{
		RequestId = requestId;
		IsFromBinding = isFromBinding;
	}

	public int RequestId { get; }

	public bool IsFromBinding { get; }
}
