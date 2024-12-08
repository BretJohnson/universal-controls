// This file is generated from ILinearGradientBrush.cs. Update the source file to change its contents.

using AnywhereUI.Media;
using BindableProperty = Microsoft.Maui.Controls.BindableProperty;

namespace AnywhereUI.Maui.Media
{
    public class LinearGradientBrush : GradientBrush, ILinearGradientBrush
    {
        public static readonly BindableProperty StartPointProperty = PropertyUtils.Register(nameof(StartPoint), typeof(Point), typeof(LinearGradientBrush), default(Point));
        public static readonly BindableProperty EndPointProperty = PropertyUtils.Register(nameof(EndPoint), typeof(Point), typeof(LinearGradientBrush), default(Point));
        
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
