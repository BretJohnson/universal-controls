namespace UniversalUI;


/// <summary>
/// Describes the thickness of a frame around a rectangle. Four float values describe the Left, Top,
/// Right, and Bottom sides of the rectangle, respectively.
/// </summary>
public struct ThicknessF
{
    public static readonly Thickness Default = new Thickness();

    /// <summary>
    /// The left side measure of the Thickness.
    /// </summary>
    public float Left { get; set; }

    /// <summary>
    /// The top edge measure of the Thickness.
    /// </summary>
    public float Top { get; set; }

    /// <summary>
    /// The right side measure of the Thickness.
    /// </summary>
    public float Right { get; set; }

    /// <summary>
    /// The bottom edge measure of the Thickness.
    /// </summary>
    public float Bottom { get; set; }

    public ThicknessF(float uniformLength) : this(uniformLength, uniformLength, uniformLength, uniformLength)
    {
    }

    public ThicknessF(float left, float top, float right, float bottom) : this()
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    public float HorizontalThickness => Left + Right;

    public float VerticalThickness => Top + Bottom;

    public bool IsEmpty => Left == 0 && Top == 0 && Right == 0 && Bottom == 0;

    private bool Equals(Thickness other)
    {
        return Left.Equals(other.Left) && Top.Equals(other.Top) && Right.Equals(other.Right) && Bottom.Equals(other.Bottom);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        return obj is ThicknessF && Equals((ThicknessF)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = Left.GetHashCode();
            hashCode = (hashCode * 397) ^ Top.GetHashCode();
            hashCode = (hashCode * 397) ^ Right.GetHashCode();
            hashCode = (hashCode * 397) ^ Bottom.GetHashCode();
            return hashCode;
        }
    }

    public static bool operator ==(ThicknessF left, ThicknessF right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ThicknessF left, ThicknessF right)
    {
        return !left.Equals(right);
    }
}
