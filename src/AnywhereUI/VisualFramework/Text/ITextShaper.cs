using System;

namespace AnywhereUI.VisualFramework.Text;

public interface ITextShaper : IDisposable
{
    public ITypeface Typeface { get; }

    public ITextShapeResult Shape(string text, float xOffset, float yOffset, IFont font);
}
