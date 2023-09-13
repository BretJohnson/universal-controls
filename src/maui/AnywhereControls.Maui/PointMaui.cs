using System.ComponentModel;
using Microsoft.Maui.Controls;
using AnywhereControls.Maui.Converters;

namespace AnywhereControls.Maui
{
    [TypeConverter(typeof(PointTypeConverter))]
    public struct PointMaui
    {
        public static readonly PointMaui Default = new PointMaui(Point.Default);
        public static readonly PointMaui CenterDefault = new PointMaui(Point.CenterDefault);

        public Point Point { get; }

        public PointMaui(Point point)
        {
            Point = point;
        }
    }
}