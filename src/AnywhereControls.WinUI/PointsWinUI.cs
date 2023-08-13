namespace Microsoft.StandardUI.WinUI
{
    //[TypeConverter(typeof(PointsTypeConverter))]
    public struct PointsWinUI
    {
        public static readonly PointsWinUI Default = new PointsWinUI(Points.Default);


        public Points Points { get; }

        public PointsWinUI(Points points)
        {
            Points = points;
        }
    }
}
