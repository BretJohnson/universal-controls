using System.ComponentModel;
using AnywhereControls.Wpf.Converters;

namespace AnywhereControls.Wpf
{
    [TypeConverter(typeof(PointsTypeConverter))]
    public struct PointsWpf
    {
        public static readonly PointsWpf Default = new PointsWpf(Points.Default);

        public Points Points { get; }

        public PointsWpf(Points points)
        {
            Points = points;
        }
    }
}
