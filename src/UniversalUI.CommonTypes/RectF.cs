using System;

namespace AnywhereUI;

/// <summary>
/// Contains number values that represent the location and size of a rectangle.
/// </summary>
public struct RectF
{
    /// <summary>
    /// Gets or sets the x-axis value of the left side of the rectangle.
    /// </summary>
    public float X { get; set; }

    /// Gets or sets the y-axis value of the top side of the rectangle.
    /// <summary>
    /// </summary>
    public float Y { get; set; }

    /// <summary>
    /// Gets or sets the width of the rectangle.
    /// </summary>
    public float Width { get; set; }

    /// <summary>
    /// Gets or sets the height of the rectangle.
    /// </summary>
    public float Height { get; set; }

    public RectF(float x, float y, float width, float height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public RectF(PointF location, SizeF size)
    {
        X = location.X;
        Y = location.Y;
        Width = size.Width;
        Height = size.Height;
    }

    /// <summary>
    /// Gets the x-axis value of the left side of the rectangle.
    /// </summary>
    public float Left => X;

    /// <summary>
    /// Gets the y-axis position of the top of the rectangle.
    /// </summary>
    public float Top => Y;

    /// <summary>
    /// Gets the x-axis value of the right side of the rectangle.
    /// </summary>
    public float Right => X + Width;

    /// <summary>
    /// Gets the y-axis value of the bottom of the rectangle.
    /// </summary>
    public float Bottom => Y + Height;

    /// <summary>
    /// Gets the position of the top-left corner of the rectangle.
    /// </summary>
    public PointF TopLeft => new PointF(Left, Top);

    /// <summary>
    /// Gets the position of the top-right corner of the rectangle.
    /// </summary>
    public PointF TopRight => new PointF(Right, Top);

    /// <summary>
    /// Gets the position of the bottom-left corner of the rectangle.
    /// </summary>
    public PointF BottomLeft => new PointF(Left, Bottom);

    /// <summary>
    /// Gets the position of the bottom-right corner of the rectangle.
    /// </summary>
    public PointF BottomRight => new PointF(Right, Bottom);

    /// <summary>
    /// Gets or sets the width and height of the rectangle.
    /// </summary>
    public SizeF Size
    {
        get => new SizeF(Width, Height);
        set
        {
            Width = value.Width;
            Height = value.Height;
        }
    }

    /// <summary>
    /// Expands the rectangle represented by the current Rect exactly enough to contain the specified rectangle.
    /// </summary>
    public void Union(RectF rect)
    {
        float left = Math.Min(Left, rect.Left);
        float top = Math.Min(Top, rect.Top);

        //  Max with 0 to prevent float weirdness from causing us to be (-epsilon..0)
        float maxRight = Math.Max(Right, rect.Right);
        Width = Math.Max(maxRight - left, 0);

        //  Max with 0 to prevent float weirdness from causing us to be (-epsilon..0)
        float maxBottom = Math.Max(Bottom, rect.Bottom);
        Height = Math.Max(maxBottom - top, 0);

        X = left;
        Y = top;
    }

    /// <summary>
    /// Expands the rectangle represented by the current Rect exactly enough to contain the specified point.
    /// </summary>
    public void Union(PointF point)
    {
        Union(new RectF(point.X, point.Y, 0, 0));
    }
}
