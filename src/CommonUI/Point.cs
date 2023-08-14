namespace CommonUI
{
    public struct Point
    {
        public static readonly Point Default = new Point(0, 0);
        public static readonly Point CenterDefault = new Point(0.5, 0.5);

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point WithX(double x) => new Point(x, Y);

        public Point WithY(double y) => new Point(X, y);
    }
}
