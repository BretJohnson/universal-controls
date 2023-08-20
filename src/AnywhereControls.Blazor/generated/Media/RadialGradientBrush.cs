// This file is generated from IRadialGradientBrush.cs. Update the source file to change its contents.

using AnywhereControls.DefaultImplementations;
using CommonUI;
using Microsoft.AspNetCore.Components;
using AnywhereControls.Media;

namespace AnywhereControls.Blazor.Media
{
    public class RadialGradientBrush : GradientBrush, IRadialGradientBrush
    {
        public static readonly UIProperty CenterProperty = new UIProperty(nameof(Center), Point.CenterDefault);
        public static readonly UIProperty GradientOriginProperty = new UIProperty(nameof(GradientOrigin), Point.CenterDefault);
        public static readonly UIProperty RadiusXProperty = new UIProperty(nameof(RadiusX), 0.5);
        
        [Parameter]
        public Point Center
        {
            get => (Point) GetNonNullValue(CenterProperty);
            set => SetValue(CenterProperty, value);
        }
        
        [Parameter]
        public Point GradientOrigin
        {
            get => (Point) GetNonNullValue(GradientOriginProperty);
            set => SetValue(GradientOriginProperty, value);
        }
        
        [Parameter]
        public double RadiusX
        {
            get => (double) GetNonNullValue(RadiusXProperty);
            set => SetValue(RadiusXProperty, value);
        }
    }
}
