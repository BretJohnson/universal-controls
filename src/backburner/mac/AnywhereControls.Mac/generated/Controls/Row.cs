// This file is generated from IRow.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using AnywhereControls.Controls;

namespace AnywhereControls.Mac.Controls
{
    public class Row : Panel, IRow
    {
        public static readonly UIProperty HeightProperty = new UIProperty(nameof(Height), GridLength.Default);
        public static readonly UIProperty MinHeightProperty = new UIProperty(nameof(MinHeight), 0.0);
        public static readonly UIProperty MaxHeightProperty = new UIProperty(nameof(MaxHeight), double.PositiveInfinity);
        public static readonly UIProperty ActualHeightProperty = new UIProperty(nameof(ActualHeight), 0.0, readOnly:true);
        
        public GridLength Height
        {
            get => (GridLength) GetNonNullValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }
        
        public double MinHeight
        {
            get => (double) GetNonNullValue(MinHeightProperty);
            set => SetValue(MinHeightProperty, value);
        }
        
        public double MaxHeight
        {
            get => (double) GetNonNullValue(MaxHeightProperty);
            set => SetValue(MaxHeightProperty, value);
        }
        
        public double ActualHeight => (double) GetNonNullValue(ActualHeightProperty);
    }
}
