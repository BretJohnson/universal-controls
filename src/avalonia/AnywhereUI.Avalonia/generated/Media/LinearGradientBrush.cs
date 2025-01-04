// This file is generated from ILinearGradientBrush.cs. Update the source file to change its contents.

using AnywhereUI;
using AnywhereUI.Media;
using AvaloniaProperty = Avalonia.AvaloniaProperty;

namespace AnywhereUIAvalonia.Media
{
    public class LinearGradientBrush : GradientBrush, ILinearGradientBrush
    {
        public static readonly Avalonia.StyledProperty<Point> StartPointProperty = AvaloniaProperty.Register<LinearGradientBrush, Point>(nameof(StartPoint), default(Point));
        public static readonly Avalonia.StyledProperty<Point> EndPointProperty = AvaloniaProperty.Register<LinearGradientBrush, Point>(nameof(EndPoint), default(Point));
        
        public Point StartPoint
        {
            get => (Point) GetValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }
        
        public Point EndPoint
        {
            get => (Point) GetValue(EndPointProperty);
            set => SetValue(EndPointProperty, value);
        }
    }
}
