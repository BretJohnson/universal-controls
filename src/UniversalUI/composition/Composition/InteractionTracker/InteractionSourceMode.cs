// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Composition.Interactions;

public enum InteractionSourceMode
{
	/// <summary>
	/// Interaction is disabled.
	/// </summary>
	Disabled = 0,

	/// <summary>
	/// Interaction is enabled with inertia.
	/// </summary>
	EnabledWithInertia = 1,

	/// <summary>
	/// Interaction is enabled without inertia.
	/// </summary>
	EnabledWithoutInertia = 2,
}
