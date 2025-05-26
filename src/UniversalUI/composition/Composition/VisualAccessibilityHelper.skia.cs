// This file is copied, with modifications, from the Uno project

using System;
using UniversalUI.Composition;

namespace Uno.Helpers;

internal static class VisualAccessibilityHelper
{
	internal static Action<Visual>? ExternalOnVisualOffsetOrSizeChanged { get; set; }
}
