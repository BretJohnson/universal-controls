// This file is generated from IRow.cs. Update the source file to change its contents.

using Microsoft.StandardUI.Controls;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Controls
{
    public class Row : Panel, IRow
    {
        public static readonly DependencyProperty HeightProperty = PropertyUtils.Register(nameof(Height), typeof(GridLength), typeof(RowDefinition), GridLength.Default);
        public static readonly DependencyProperty MinHeightProperty = PropertyUtils.Register(nameof(MinHeight), typeof(double), typeof(RowDefinition), 0.0);
        public static readonly DependencyProperty MaxHeightProperty = PropertyUtils.Register(nameof(MaxHeight), typeof(double), typeof(RowDefinition), double.PositiveInfinity);
        public static readonly DependencyProperty ActualHeightProperty = PropertyUtils.Register(nameof(ActualHeight), typeof(double), typeof(RowDefinition), 0.0);
        
        public GridLength Height
        {
            get => (GridLength) GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }
        
        public double MinHeight
        {
            get => (double) GetValue(MinHeightProperty);
            set => SetValue(MinHeightProperty, value);
        }
        
        public double MaxHeight
        {
            get => (double) GetValue(MaxHeightProperty);
            set => SetValue(MaxHeightProperty, value);
        }
        
        public double ActualHeight => (double) GetValue(ActualHeightProperty);
    }
}
