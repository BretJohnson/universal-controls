// This file is generated from ILinearGradientBrush.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using CommonUI;
using Microsoft.AspNetCore.Components;
using AnywhereControls.Media;

namespace AnywhereControls.Blazor.Media
{
    public class LinearGradientBrush : GradientBrush, ILinearGradientBrush
    {
        public static readonly UIProperty StartPointProperty = new UIProperty(nameof(StartPoint), default(Point));
        public static readonly UIProperty EndPointProperty = new UIProperty(nameof(EndPoint), default(Point));
        
        [Parameter]
        public Point StartPoint
        {
            get => (Point) GetNonNullValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }
        
        [Parameter]
        public Point EndPoint
        {
            get => (Point) GetNonNullValue(EndPointProperty);
            set => SetValue(EndPointProperty, value);
        }
    }
}
