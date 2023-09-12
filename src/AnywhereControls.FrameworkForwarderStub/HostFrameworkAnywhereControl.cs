using System;

namespace AnywhereControls.Controls;

/// <summary>
/// This class is only used at build time, not runtime. At runtime, the
/// host UI framework assembly (AnywhereControls.Wpf, AnywhereControls.Maui, etc.)
/// provides its own implementation of this class, loaded by a matching
/// AnywhereControls.FrameworkFordwarder.dll assembly that has a TypeForwardedTo
/// to that implementation.
/// </summary>
public abstract class HostFrameworkAnywhereControl : IAnywhereControl
{
    void IUIObject.ClearValue(IUIProperty property) => throw NotSupportedException();
    object IUIObject.GetValue(IUIProperty property) => throw NotSupportedException();
    object IUIObject.ReadLocalValue(IUIProperty property) => throw NotSupportedException();
    void IUIObject.SetValue(IUIProperty property, object value) => throw NotSupportedException();

    double IUIElement.Width { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    double IUIElement.MinWidth { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    double IUIElement.MaxWidth { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    double IUIElement.Height { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    double IUIElement.MinHeight { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    double IUIElement.MaxHeight { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    Thickness IUIElement.Margin { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    HorizontalAlignment IUIElement.HorizontalAlignment { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    VerticalAlignment IUIElement.VerticalAlignment { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    FlowDirection IUIElement.FlowDirection { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    Rect IUIElement.Frame { get => throw NotSupportedException(); }
    Size IUIElement.DesiredSize { get => throw NotSupportedException(); }
    double IUIElement.ActualX { get => throw NotSupportedException(); }
    double IUIElement.ActualY { get => throw NotSupportedException(); }
    double IUIElement.ActualWidth { get => throw NotSupportedException(); }
    double IUIElement.ActualHeight { get => throw NotSupportedException(); }
    bool IUIElement.Visible { get => throw NotSupportedException(); set => throw NotSupportedException(); }
    int IUIElement.VisualChildrenCount { get => throw NotSupportedException(); }

    void IUIElement.Arrange(Rect finalRect) => throw NotSupportedException();
    IUIElement IUIElement.GetVisualChild(int index) => throw NotSupportedException();
    void IUIElement.Measure(Size availableSize) => throw NotSupportedException();

    protected virtual IUIElement? BuildContent => throw new NotSupportedException();
    protected abstract IUIElement Build();

    private Exception NotSupportedException()
    {
        return new NotImplementedException();
    }
}
