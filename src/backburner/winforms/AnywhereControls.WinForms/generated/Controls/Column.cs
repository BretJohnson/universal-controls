// This file is generated from IColumn.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;
using AnywhereUI.Controls;

namespace AnywhereControls.WinForms.Controls
{
    public class Column : Panel, IColumn
    {
        public static readonly UIProperty WidthProperty = new UIProperty(nameof(Width), GridLength.Default);
        public static readonly UIProperty MinWidthProperty = new UIProperty(nameof(MinWidth), 0.0);
        public static readonly UIProperty MaxWidthProperty = new UIProperty(nameof(MaxWidth), double.PositiveInfinity);
        public static readonly UIProperty ActualWidthProperty = new UIProperty(nameof(ActualWidth), 0.0, readOnly:true);
        
        public GridLength Width
        {
            get => (GridLength) GetNonNullValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }
        
        public double MinWidth
        {
            get => (double) GetNonNullValue(MinWidthProperty);
            set => SetValue(MinWidthProperty, value);
        }
        
        public double MaxWidth
        {
            get => (double) GetNonNullValue(MaxWidthProperty);
            set => SetValue(MaxWidthProperty, value);
        }
        
        public double ActualWidth => (double) GetNonNullValue(ActualWidthProperty);
    }
}
