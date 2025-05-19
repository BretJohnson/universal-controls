// This file is generated. Update the source to change its contents.

using AnywhereUI.Wpf;
using System;
using System.Windows.Input;
using AnywhereUI.Input;
using AnywhereUI.Wpf.Input;
using Visibility = System.Windows.Visibility;

namespace AnywhereUI.Controls
{
    public partial class HostFrameworkAnywhereControl
    {
        private EventHandlersStore? _eventHandlersStore;
        
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
            get => HorizontalAlignment.ToStandardUIHorizontalAlignment();
            set => HorizontalAlignment = value.ToWpfHorizontalAlignment();
        }
        
        VerticalAlignment IUIElement.VerticalAlignment
        {
            get => VerticalAlignment.ToAnywhereControlsVerticalAlignment();
            set => VerticalAlignment = value.ToWpfVerticalAlignment();
        }
        
        FlowDirection IUIElement.FlowDirection
        {
            get => FlowDirection.ToStandardUIFlowDirection();
            set => FlowDirection = value.ToWpfFlowDirection();
        }
        
        bool IUIElement.Visible
        {
            get => Visibility != Visibility.Collapsed;
            set => Visibility = value ? Visibility.Visible : Visibility.Collapsed;
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
}
