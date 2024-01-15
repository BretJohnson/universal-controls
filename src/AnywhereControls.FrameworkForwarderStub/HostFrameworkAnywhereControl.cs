using System;
using AnywhereControls.Input;

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
    void IUIObject.ClearValue(IUIProperty property) => throw CreateNotSupportedException();
    object IUIObject.GetValue(IUIProperty property) => throw CreateNotSupportedException();
    void IUIObject.SetValue(IUIProperty property, object? value) => throw CreateNotSupportedException();

    double IUIElement.Width { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    double IUIElement.MinWidth { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    double IUIElement.MaxWidth { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    double IUIElement.Height { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    double IUIElement.MinHeight { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    double IUIElement.MaxHeight { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    Thickness IUIElement.Margin { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    HorizontalAlignment IUIElement.HorizontalAlignment { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    VerticalAlignment IUIElement.VerticalAlignment { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    FlowDirection IUIElement.FlowDirection { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    Rect IUIElement.Frame { get => throw CreateNotSupportedException(); }
    Size IUIElement.DesiredSize { get => throw CreateNotSupportedException(); }
    double IUIElement.ActualX { get => throw CreateNotSupportedException(); }
    double IUIElement.ActualY { get => throw CreateNotSupportedException(); }
    double IUIElement.ActualWidth { get => throw CreateNotSupportedException(); }
    double IUIElement.ActualHeight { get => throw CreateNotSupportedException(); }
    bool IUIElement.Visible { get => throw CreateNotSupportedException(); set => throw CreateNotSupportedException(); }
    int IUIElement.VisualChildrenCount { get => throw CreateNotSupportedException(); }

    void IUIElement.Arrange(Rect finalRect) => throw CreateNotSupportedException();
    IUIElement IUIElement.GetVisualChild(int index) => throw CreateNotSupportedException();
    void IUIElement.Measure(Size availableSize) => throw CreateNotSupportedException();

    protected virtual IUIElement? BuildContent => throw CreateNotSupportedException();

    protected abstract IUIElement Build();

    public abstract event PointerEventHandler? PointerEntered;
    public abstract event PointerEventHandler? PointerExited;
    public abstract event PointerEventHandler? PointerMoved;

    private Exception CreateNotSupportedException() =>
        new InvalidOperationException("This class shouldn't ever be instantiated, just used at build time. At runtime, HostFrameworkAnywhereControl should come from the host framework specific assembly");
}
