using System;
using AnywhereUI.Input;
using System.Windows.Input;
using AnywhereUI.Wpf;
using AnywhereUI.Wpf.Input;
using AnywhereUI.Wpf.NativeVisualFramework;
using AnywhereUI.VisualFramework;
using System.Windows.Media;

namespace AnywhereUI;

public abstract class HostFrameworkAnywhereUIElement : System.Windows.FrameworkElement, IUIElement, ILogicalParent
{
    private EventHandlersStore? _eventHandlersStore;
    private StandardUIFrameworkElementHelper _helper = new();

    public HostFrameworkAnywhereUIElement()
    {
        if (!HostEnvironment.IsInitialized)
        {
            WpfHostFramework.Init(new WpfNativeVisualFramework());
        }
    }

    protected override void OnRender(DrawingContext drawingContextWpf)
    {
        base.OnRender(drawingContextWpf);

        if (Visibility != System.Windows.Visibility.Visible)
            return;

        if (this is not IDrawable drawable)
            return;

        IVisualFramework visualFramework = HostEnvironment.VisualFramework;

        using (IDrawingContext drawingContext = visualFramework.CreateDrawingContext(this))
        {
            drawable.Draw(drawingContext);
            IVisual? visual = drawingContext.Close();

            if (visual != null)
            {
                _helper.OnRender(visual, Width, Height, drawingContextWpf);
            }
        }
    }

    protected override void OnRenderSizeChanged(System.Windows.SizeChangedInfo sizeInfo)
    {
        base.OnRenderSizeChanged(sizeInfo);
        InvalidateVisual();
    }

    protected override System.Windows.Size MeasureOverride(System.Windows.Size constraint)
    {
        ((IUIElement) this).Measure(constraint.ToAnywhereControlsSize());
        return ((IUIElement)this).DesiredSize.ToWpfSize();
    }

    protected override System.Windows.Size ArrangeOverride(System.Windows.Size arrangeSize)
    {
        ((IUIElement) this).Arrange(new Rect(0, 0, arrangeSize.Width, arrangeSize.Height));
        return arrangeSize;
    }

    int IUIElement.VisualChildrenCount => SingleChild != null ? 1 : 0;

    IUIElement IUIElement.GetVisualChild(int index)
    {
        if (SingleChild == null)
            throw new ArgumentOutOfRangeException("index", index, "UIElement has no content");
        if (index != 0)
            throw new ArgumentOutOfRangeException("index", index, "Index out of range; UIElement only has a single visual child");

        return SingleChild;
    }

    public Rect Frame => throw new NotImplementedException();

    void ILogicalParent.AddLogicalChild(object child) => AddLogicalChild(child);

    void ILogicalParent.RemoveLogicalChild(object child) => RemoveLogicalChild(child);

    protected virtual IUIElement? SingleChild => null;

    protected virtual void OnSingleChildChanged(IUIElement? oldChild, IUIElement? newChild)
    {
        if (oldChild != null)
        {
            System.Windows.UIElement wpfUIElement = oldChild.ToWpfUIElement();
            RemoveVisualChild(wpfUIElement);
            RemoveLogicalChild(wpfUIElement);
        }

        if (newChild != null)
        {
            System.Windows.UIElement wpfUIElement = newChild.ToWpfUIElement();
            AddVisualChild(wpfUIElement);
            AddLogicalChild(wpfUIElement);
        }
    }

    void IUIElement.Measure(Size availableSize) => Measure(availableSize.ToWpfSize());
    void IUIElement.Arrange(Rect finalRect) => Arrange(finalRect.ToWpfRect());
    Size IUIElement.DesiredSize => DesiredSize.ToAnywhereControlsSize();

    double IUIElement.ActualX => throw new NotImplementedException();
    double IUIElement.ActualY => throw new NotImplementedException();
    Thickness IUIElement.Margin
    {
        get => Margin.ToAnywhereControlsThickness();
        set => Margin = value.ToWpfThickness();
    }

    HorizontalAlignment IUIElement.HorizontalAlignment
    {
        get => HorizontalAlignment.ToAnywhereUIHorizontalAlignment();
        set => HorizontalAlignment = value.ToWpfHorizontalAlignment();
    }

    VerticalAlignment IUIElement.VerticalAlignment
    {
        get => VerticalAlignment.ToAnywhereControlsVerticalAlignment();
        set => VerticalAlignment = value.ToWpfVerticalAlignment();
    }

    FlowDirection IUIElement.FlowDirection
    {
        get => FlowDirection.ToAnywhereUIFlowDirection();
        set => FlowDirection = value.ToWpfFlowDirection();
    }

    bool IUIElement.Visible
    {
        get => Visibility != System.Windows.Visibility.Collapsed;
        set => Visibility = value ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
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

    double IUIElement.ActualWidth => ActualWidth;
    double IUIElement.ActualHeight => ActualHeight;

    object? IUIObject.GetValue(IUIProperty property) => GetValue(((UIProperty)property).DependencyProperty);
    void IUIObject.SetValue(IUIProperty property, object? value) => SetValue(((UIProperty)property).DependencyProperty, value);
    void IUIObject.ClearValue(IUIProperty property) => ClearValue(((UIProperty)property).DependencyProperty);

    protected override int VisualChildrenCount =>
        ((IUIElement)this).VisualChildrenCount;

    protected override System.Windows.Media.Visual GetVisualChild(int index) =>
        ((IUIElement)this).GetVisualChild(index).ToWpfUIElement();

    //
    // Event support
    //

    protected bool AddRoutedEventHandler(RoutedEvent routedEvent, Delegate handler)
    {
        if (_eventHandlersStore == null)
        {
            _eventHandlersStore = new EventHandlersStore();
        }

        return _eventHandlersStore.AddRoutedEventHandler(routedEvent, handler);
    }

    protected bool AddRoutedEventHandler(RoutedEvent routedEvent, Delegate handler, bool handledEventsToo)
    {
        if (_eventHandlersStore == null)
        {
            _eventHandlersStore = new EventHandlersStore();
        }

        return _eventHandlersStore.AddRoutedEventHandler(routedEvent, handler, handledEventsToo);
    }

    protected bool RemoveRoutedEventHandler(RoutedEvent routedEvent, Delegate handler) =>
        _eventHandlersStore?.RemoveRoutedEventHandler(routedEvent, handler) ?? false;

    public void RaiseHandleableEvent(RoutedEvent routedEvent, IHandleableRoutedEventArgs e) =>
        _eventHandlersStore?.RaiseHandleableEvent(routedEvent, this, e);

    public void RaiseNonhandleableEvent(RoutedEvent routedEvent, IRoutedEventArgs e) =>
        _eventHandlersStore?.RaiseNonhandleableEvent(routedEvent, this, e);

    public event PointerEventHandler PointerEntered
    {
        add
        {
            if (AddRoutedEventHandler(InputEvents.PointerEnteredEvent, value))
            {
                MouseEnter += OnMouseEnter;
            }
        }
        remove
        {
            if (RemoveRoutedEventHandler(InputEvents.PointerEnteredEvent, value))
            {
                MouseEnter -= OnMouseEnter;
            }
        }
    }
    private void OnMouseEnter(object sender, MouseEventArgs e) =>
        RaiseHandleableEvent(InputEvents.PointerEnteredEvent, new MousePointerEventArgs(e));

    public event PointerEventHandler PointerExited
    {
        add
        {
            if (AddRoutedEventHandler(InputEvents.PointerExitedEvent, value))
            {
                MouseLeave += OnMouseLeave;
            }
        }
        remove
        {
            if (RemoveRoutedEventHandler(InputEvents.PointerExitedEvent, value))
            {
                MouseLeave -= OnMouseLeave;
            }
        }
    }
    private void OnMouseLeave(object sender, MouseEventArgs e) =>
        RaiseHandleableEvent(InputEvents.PointerExitedEvent, new MousePointerEventArgs(e));

    public event PointerEventHandler PointerMoved
    {
        add
        {
            if (AddRoutedEventHandler(InputEvents.PointerMovedEvent, value))
            {
                MouseMove += OnMouseMove;
            }
        }
        remove
        {
            if (RemoveRoutedEventHandler(InputEvents.PointerMovedEvent, value))
            {
                MouseMove -= OnMouseMove;
            }
        }
    }

    private void OnMouseMove(object sender, MouseEventArgs e) =>
        RaiseHandleableEvent(InputEvents.PointerMovedEvent, new MousePointerEventArgs(e));
}
