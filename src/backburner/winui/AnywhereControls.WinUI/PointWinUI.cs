//using AnywhereControls.WinUI.Converters;

namespace AnywhereControls.WinUI
{
    //[TypeConverter(typeof(PointTypeConverter))]
    public struct PointWinUI
    {
        public static readonly PointWinUI Default = new PointWinUI(Point.Default);
        public static readonly PointWinUI CenterDefault = new PointWinUI(Point.CenterDefault);


        public Point Point { get; }

        public PointWinUI(Point point)
        {
            Point = point;
        }
    }
}
