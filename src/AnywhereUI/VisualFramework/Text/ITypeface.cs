using System;
using AnywhereUI.Media;
using AnywhereUI.Text;

namespace AnywhereUI.VisualFramework.Text;

/// <summary>
/// A typeface represents the raw font data/design - it defines the actual shape and look of the characters. Think of it as the font file itself.
/// </summary>
public interface ITypeface : IDisposable
{
    FontFamily FontFamily { get; }
    FontStyle Style { get; }
    FontWeight Weight { get; }
    FontStretch Stretch { get; }
}
