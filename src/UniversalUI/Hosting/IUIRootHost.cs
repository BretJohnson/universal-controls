// This file is copied, with modifications, from the Uno project.

using UniversalUI.Composition;
using UniversalUI.Controls;

namespace UniversalUI.Hosting;

/// <summary>
/// This interface is intended to only be used by platform host frameworks.
/// </summary>
public interface IUIRootHost
{
	IUIElement? RootElement { get; }

    ContainerVisual? RootElementVisual => (RootElement as AnywhereControl)?.Visual;

    void InvalidateRender();

    /// <summary>
    /// Gets a value that represents the number of raw (physical) pixels for each view pixel.
    /// </summary>
    double RasterizationScale { get; }
}
