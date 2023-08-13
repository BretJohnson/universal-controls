using System.ComponentModel;
using Microsoft.Maui.Graphics;
using Microsoft.StandardUI.Wpf.Converters;

namespace Microsoft.StandardUI.Wpf
{
    [TypeConverter(typeof(PointTypeConverter))]
    public struct PointWpf
    {
        public static readonly PointWpf Default = new PointWpf(default(Point));
        public static readonly PointWpf CenterDefault = new PointWpf(new Point(0.5, 0.5));

        public Point Point { get; }

        public PointWpf(Point point)
        {
            Point = point;
        }

        public PointWpf(double x, double y)
        {
            Point = new Point(x, y);
        }
    }
}
