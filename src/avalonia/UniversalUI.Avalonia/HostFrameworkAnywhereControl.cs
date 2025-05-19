using AnywhereUIAvalonia;
using AnywhereUIAvalonia.NativeVisualFramework;
using Avalonia.Controls;

namespace AnywhereControls.Controls;

public abstract class HostFrameworkAnywhereControl : Control, IAnywhereControl, ILogicalParent
{
    protected IUIElement? _buildContent;
    private bool _invalid = true;

    public HostFrameworkAnywhereControl()
    {
        if (!HostEnvironment.IsInitialized)
        {
            AvaloniaHostFramework.Init(new AvaloniaNativeVisualFramework());
        }
    }

    protected IUIElement? BuildContent => _buildContent;

    protected override Avalonia.Size MeasureOverride(Avalonia.Size availableSize)
    {
        if (_invalid)
        {
            Rebuild();
            _invalid = false;
        }

        ((IUIElement) this).Measure(availableSize.ToAnywhereControlsSize());
        return ((IUIElement)this).DesiredSize.ToAvaloniaSize();
    }

    protected override Avalonia.Size ArrangeOverride(Avalonia.Size arrangeSize)
    {
        ((IUIElement) this).Arrange(new Rect(0, 0, arrangeSize.Width, arrangeSize.Height));
        return arrangeSize;
    }

    int IUIElement.VisualChildrenCount => _buildContent != null ? 1 : 0;

    IUIElement IUIElement.GetVisualChild(int index)
    {
        if (_buildContent == null)
            throw new ArgumentOutOfRangeException("index", index, "Control returned null from build");
        if (index != 0)
            throw new ArgumentOutOfRangeException("index", index, "Index out of range; control only has a single visual child.");

        return _buildContent;
    }

    public Rect Frame => throw new NotImplementedException();

    // TODO: Implement as needed
    void ILogicalParent.AddLogicalChild(object child) => throw new NotImplementedException();

    void ILogicalParent.RemoveLogicalChild(object child) => throw new NotImplementedException();

    private void Rebuild()
    {
        if (_buildContent != null)
        {
            Control avaloniaControl = _buildContent.ToAvaloniaControl();
            VisualChildren.Remove(avaloniaControl);
            LogicalChildren.Remove(avaloniaControl);
            _buildContent = null;
        }

        _buildContent = this.Build();

        if (_buildContent != null)
        {
            Control avaloniaControl = _buildContent.ToAvaloniaControl();
            VisualChildren.Add(avaloniaControl);
            LogicalChildren.Add(avaloniaControl);
        }
    }

    void IUIElement.Measure(Size desiredSize) =>
        Measure(new Avalonia.Size(desiredSize.Width, desiredSize.Height));
    void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToAvaloniaRect());
    Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();

    double IUIElement.ActualX => throw new System.NotImplementedException();
    double IUIElement.ActualY => throw new System.NotImplementedException();

    Thickness IUIElement.Margin
    {
        get => Margin.ToAnywhereControlsThickness();
        set => Margin = value.ToAvaloniaThickness();
    }

    HorizontalAlignment IUIElement.HorizontalAlignment
    {
        get => HorizontalAlignment.ToAnywhereControlsHorizontalAlignment();
        set => HorizontalAlignment = value.ToAvaloniaHorizontalAlignment();
    }

    VerticalAlignment IUIElement.VerticalAlignment
    {
        get => VerticalAlignment.ToAnywhereControlsVerticalAlignment();
        set => VerticalAlignment = value.ToAvaloniaVerticalAlignment();
    }

    FlowDirection IUIElement.FlowDirection
    {
        get => FlowDirection.ToStandardUIFlowDirection();
        set => FlowDirection = value.ToAvaloniaFlowDirection();
    }

    bool IUIElement.Visible
    {
        get => IsVisible;
        set => IsVisible = value;
    }

    double IUIElement.Width
    {
        get => Width;
        set => Width = value;
    }

    double IUIElement.MinWidth
    {
        get => MinWidth;
        set => MinWidth = value;
    }

    double IUIElement.MaxWidth
    {
        get => MaxWidth;
        set => MaxWidth = value;
    }

    double IUIElement.Height
    {
        get => Height;
        set => Height = value;
    }

    double IUIElement.MinHeight
    {
        get => MinHeight;
        set => MinHeight = value;
    }

    double IUIElement.MaxHeight
    {
        get => MaxHeight;
        set => MaxHeight = value;
    }

    double IUIElement.ActualWidth => Bounds.Width;
    double IUIElement.ActualHeight => Bounds.Height;

    object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).AvaloniaProperty);
    void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).AvaloniaProperty, value);
    void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).AvaloniaProperty);

#if LATER
    protected override int VisualChildrenCount => 
        ((IUIElement)this).VisualChildrenCount;
    protected override Avalonia.Media.Visual GetVisualChild(int index) =>
        ((IUIElement)this).GetVisualChild(index).ToAvaloniaControl();
#endif

    protected abstract IUIElement? Build();
}
