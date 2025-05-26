// This file is copied, with modifications, from the Uno project

#nullable disable

namespace UniversalUI.Composition.Interactions;

public partial class InteractionTrackerRequestIgnoredArgs
{
	internal InteractionTrackerRequestIgnoredArgs(int requestId)
		=> RequestId = requestId;

	public int RequestId { get; }
}
