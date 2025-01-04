using System;

namespace AnywhereUI.VisualFramework.Text;

/// <summary>
/// A font is a higher-level object that specifies how to render text using a typeface. Beyond the typeface, it includes additional
/// rendering properties like text size.
/// </summary>
public interface IFont : IDisposable
{
    ITypeface Typeface { get; }

    double Size { get; }
}
