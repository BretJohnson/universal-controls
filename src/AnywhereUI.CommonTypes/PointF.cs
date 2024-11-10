namespace AnywhereControls;

public readonly struct PointF
{
    public static readonly PointF Default = new PointF(0, 0);
    public static readonly PointF CenterDefault = new PointF((float) 0.5, (float)0.5);

    private readonly float _x;
    private readonly float _y;

    public float X => _x;
    public float Y => _y;

    public PointF(float x, float y)
    {
        _x = x;
        _y = y;
    }

    public PointF WithX(float x) => new PointF(x, Y);

    public PointF WithY(float y) => new PointF(X, y);
}
