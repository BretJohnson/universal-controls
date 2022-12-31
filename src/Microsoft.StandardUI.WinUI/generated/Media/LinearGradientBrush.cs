// This file is generated from ILinearGradientBrush.cs. Update the source file to change its contents.

using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Media;
using DependencyProperty = Microsoft.UI.Xaml.DependencyProperty;

namespace Microsoft.StandardUI.WinUI.Media
{
    public class LinearGradientBrush : GradientBrush, ILinearGradientBrush
    {
        public static readonly DependencyProperty StartPointProperty = PropertyUtils.Register(nameof(StartPoint), typeof(PointWinUI), typeof(LinearGradientBrush), default(Point));
        public static readonly DependencyProperty EndPointProperty = PropertyUtils.Register(nameof(EndPoint), typeof(PointWinUI), typeof(LinearGradientBrush), default(Point));
        
        public PointWinUI StartPoint
        {
            get => (PointWinUI) GetValue(StartPointProperty);
            set => SetValue(StartPointProperty, value);
        }
        Point ILinearGradientBrush.StartPoint
        {
            get => StartPoint.Point;
            set => StartPoint = new PointWinUI(value);
        }
        
        public PointWinUI EndPoint
        {
            get => (PointWinUI) GetValue(EndPointProperty);
            set => SetValue(EndPointProperty, value);
        }
        Point ILinearGradientBrush.EndPoint
        {
            get => EndPoint.Point;
            set => EndPoint = new PointWinUI(value);
        }
    }
}
