// This file is generated from IColumnDefinition.cs. Update the source file to change its contents.

using AnywhereControls.Controls;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace AnywhereControls.WinUI.Controls
{
    public class ColumnDefinition : StandardUIObject, IColumnDefinition
    {
        public static readonly DependencyProperty WidthProperty = PropertyUtils.Register(nameof(Width), typeof(GridLength), typeof(ColumnDefinition), GridLength.Default);
        public static readonly DependencyProperty MinWidthProperty = PropertyUtils.Register(nameof(MinWidth), typeof(double), typeof(ColumnDefinition), 0.0);
        public static readonly DependencyProperty MaxWidthProperty = PropertyUtils.Register(nameof(MaxWidth), typeof(double), typeof(ColumnDefinition), double.PositiveInfinity);
        public static readonly DependencyProperty ActualWidthProperty = PropertyUtils.Register(nameof(ActualWidth), typeof(double), typeof(ColumnDefinition), 0.0);
        
        public GridLength Width
        {
            get => (GridLength) GetValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }
        
        public double MinWidth
        {
            get => (double) GetValue(MinWidthProperty);
            set => SetValue(MinWidthProperty, value);
        }
        
        public double MaxWidth
        {
            get => (double) GetValue(MaxWidthProperty);
            set => SetValue(MaxWidthProperty, value);
        }
        
        public double ActualWidth => (double) GetValue(ActualWidthProperty);
    }
}
