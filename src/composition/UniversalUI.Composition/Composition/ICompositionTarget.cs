using System;
using UniversalUI.Composition.Interactions;
using UniversalUI.Input;

namespace Uno.UI.Composition;

internal interface ICompositionTarget
{
	void TryRedirectForManipulation(IPointerPoint pointerPoint, InteractionTracker tracker);

	double RasterizationScale { get; }

	event EventHandler RasterizationScaleChanged;
}
