using System;
using System.Collections;
using System.Linq;
using Microsoft.UI.Xaml;

namespace AnywhereControls.WinUI
{
    public static class PropertyUtils
    {
        public static IEnumerable Empty<T>()
        {
            return Enumerable.Empty<T>();
        }

        public static DependencyProperty Register(string propertyName, Type propertyType, Type ownerType, object? defaultValue)
        {
            var propertyMetadata = new PropertyMetadata(defaultValue, OnPropertyChanged);
            return DependencyProperty.Register(propertyName, propertyType, ownerType, propertyMetadata);
        }

        public static DependencyProperty RegisterAttached(string propertyName, Type propertyType, Type ownerType, object? defaultValue)
        {
            var propertyMetadata = new PropertyMetadata(defaultValue, OnPropertyChanged);
            return DependencyProperty.RegisterAttached(propertyName, propertyType, ownerType, propertyMetadata);
        }

        private static void OnPropertyChanged(Microsoft.UI.Xaml.DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if (!(obj is INotifyObjectOrSubobjectChanged parentObj))
                return;

            // The logic below cascades change notifications from subobjects up the object hierarchy, eventually causing the GraphicsCanvas
            // to be invalidated on any change
            if (e.OldValue is INotifyObjectOrSubobjectChanged oldChildObj)
                oldChildObj.Changed -= parentObj.NotifySinceSubobjectChanged;

            if (e.NewValue is INotifyObjectOrSubobjectChanged newChildObj)
                newChildObj.Changed += parentObj.NotifySinceSubobjectChanged;

            parentObj.NotifySinceObjectChanged();
        }
    }
}
