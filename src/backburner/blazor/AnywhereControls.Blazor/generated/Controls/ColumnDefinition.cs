// This file is generated from IColumnDefinition.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;
using Microsoft.AspNetCore.Components;
using UniversalUI.Controls;

namespace AnywhereControls.Blazor.Controls
{
    public class ColumnDefinition : StandardUIObject, IColumnDefinition
    {
        public static readonly UIProperty WidthProperty = new UIProperty(nameof(Width), GridLength.Default);
        public static readonly UIProperty MinWidthProperty = new UIProperty(nameof(MinWidth), 0.0);
        public static readonly UIProperty MaxWidthProperty = new UIProperty(nameof(MaxWidth), double.PositiveInfinity);
        public static readonly UIProperty ActualWidthProperty = new UIProperty(nameof(ActualWidth), 0.0, readOnly:true);
        
        [Parameter]
        public GridLength Width
        {
            get => (GridLength) GetNonNullValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }
        
        [Parameter]
        public double MinWidth
        {
            get => (double) GetNonNullValue(MinWidthProperty);
            set => SetValue(MinWidthProperty, value);
        }
        
        [Parameter]
        public double MaxWidth
        {
            get => (double) GetNonNullValue(MaxWidthProperty);
            set => SetValue(MaxWidthProperty, value);
        }
        
        public double ActualWidth => (double) GetNonNullValue(ActualWidthProperty);
    }
}
