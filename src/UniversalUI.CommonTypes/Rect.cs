using System;

namespace UniversalUI;

/// <summary>
/// Contains number values that represent the location and size of a rectangle.
/// </summary>
public struct Rect
{
    /// <summary>
    /// Gets or sets the x-axis value of the left side of the rectangle.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the y-axis value of the top side of the rectangle.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    public double Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// </summary>
    public double Height { get; set; }

    public Rect(double x, double y, double width, double height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public Rect(Point location, Size size)
    {
        X = location.X;
        Y = location.Y;
        Width = size.Width;
        Height = size.Height;
    }

    /// <summary>
    /// Gets the x-axis value of the left side of the rectangle.
    /// </summary>
    public double Left => X;

    /// <summary>
    /// Gets the y-axis position of the top of the rectangle.
    /// </summary>
    public double Top => Y;

    /// <summary>
    /// Gets the x-axis value of the right side of the rectangle.
    /// </summary>
    public double Right => X + Width;

    /// <summary>
    /// Gets the y-axis value of the bottom of the rectangle.
    /// </summary>
    public double Bottom => Y + Height;

    /// <summary>
    /// Gets the position of the top-left corner of the rectangle.
    /// </summary>
    public Point TopLeft => new Point(Left, Top);

    /// <summary>
    /// Gets the position of the top-right corner of the rectangle.
    /// </summary>
    public Point TopRight => new Point(Right, Top);

    /// <summary>
    /// Gets the position of the bottom-left corner of the rectangle.
    /// </summary>
    public Point BottomLeft => new Point(Left, Bottom);

    /// <summary>
    /// Gets the position of the bottom-right corner of the rectangle.
    /// </summary>
    public Point BottomRight => new Point(Right, Bottom);

    /// <summary>
    /// Gets or sets the width and height of the rectangle.
    /// </summary>
    public Size Size
    {
        get => new Size(Width, Height);
        set
        {
            Width = value.Width;
            Height = value.Height;
        }
    }

    /// <summary>
    /// Expands the rectangle represented by the current Rect exactly enough to contain the specified rectangle.
    /// </summary>
    public void Union(Rect rect)
    {
        double left = Math.Min(Left, rect.Left);
        double top = Math.Min(Top, rect.Top);

        //  Max with 0 to prevent double weirdness from causing us to be (-epsilon..0)
        double maxRight = Math.Max(Right, rect.Right);
        Width = Math.Max(maxRight - left, 0);

        //  Max with 0 to prevent double weirdness from causing us to be (-epsilon..0)
        double maxBottom = Math.Max(Bottom, rect.Bottom);
        Height = Math.Max(maxBottom - top, 0);

        X = left;
        Y = top;
    }

    /// <summary>
    /// Expands the rectangle represented by the current Rect exactly enough to contain the specified point.
    /// </summary>
    public void Union(Point point)
    {
        Union(new Rect(point.X, point.Y, 0, 0));
    }
}
