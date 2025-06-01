// This file is copied, with modifications, from the Uno project

using System;

namespace UniversalUI.Helpers;

internal static class UIElementAccessibilityHelper
{
	internal static Action<IUIElement, IUIElement, int?>? ExternalOnChildAdded { get; set; }
	internal static Action<IUIElement, IUIElement>? ExternalOnChildRemoved { get; set; }
}
