// This file is generated from ILinearGradientBrush.cs. Update the source file to change its contents.

using Microsoft.StandardUI.DefaultImplementations;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Media;

namespace Microsoft.StandardUI.Mac.Media
{
    public class LinearGradientBrush : GradientBrush, ILinearGradientBrush
    {
        public static readonly UIProperty StartPointProperty = new UIProperty(nameof(StartPoint), default(Point));
        public static readonly UIProperty EndPointProperty = new UIProperty(nameof(EndPoint), default(Point));
        
        public Point StartPoint
        {
            get => (Point) GetNonNullValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }
        
        public Point EndPoint
        {
            get => (Point) GetNonNullValue(EndPointProperty);
            set => SetValue(EndPointProperty, value);
        }
    }
}
