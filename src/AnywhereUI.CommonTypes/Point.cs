namespace AnywhereControls;

public readonly struct Point
{
    public static readonly Point Default = new Point(0, 0);
    public static readonly Point CenterDefault = new Point(0.5, 0.5);

    private readonly double _x;
    private readonly double _y;

    public double X => _x;
    public double Y => _y;

    public Point(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public Point WithX(double x) => new Point(x, Y);

    public Point WithY(double y) => new Point(X, y);
}
