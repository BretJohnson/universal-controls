// This file is copied, with modifications, from the Uno project.

using UniversalUI.Composition;
using UniversalUI.Media;

namespace UniversalUI.Controls;

/// <summary>
/// Provides properties required for border rendering.
/// </summary>
internal partial interface IBorderInfoProvider
{
	/// <summary>
	/// Gets the background brush.
	/// </summary>
	IBrush? Background { get; }

	/// <summary>
	/// Gets the background sizing.
	/// </summary>
	BackgroundSizing BackgroundSizing { get; }

	/// <summary>
	/// Gets the border brush.
	/// </summary>
	IBrush? BorderBrush { get; }

	/// <summary>
	/// Gets the border thickness.
	/// </summary>
	Thickness BorderThickness { get; }

	/// <summary>
	/// Gets the corner radius.
	/// </summary>
	CornerRadius CornerRadius { get; }

#if UNO_HAS_BORDER_VISUAL
	BorderVisual BorderVisual { get; }
#endif
}
