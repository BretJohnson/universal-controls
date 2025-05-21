using System;
using System.Globalization;

namespace UniversalUI;

/// <summary>
/// Represents number values that specify a height and width.
/// </summary>
public readonly struct SizeF
{
    private readonly float _width;
    private readonly float _height;

    public static readonly SizeF Zero;
    public static readonly SizeF Infinity = new SizeF(float.PositiveInfinity, float.PositiveInfinity);
    public static readonly SizeF Default = Zero;

    public SizeF(float width, float height)
    {
        if (float.IsNaN(width))
            throw new ArgumentException("NaN is not a valid value for width");
        if (float.IsNaN(height))
            throw new ArgumentException("NaN is not a valid value for height");
        _width = width;
        _height = height;
    }

    public float Width => _width;
    public float Height => _height;

    public static bool operator ==(SizeF s1, SizeF s2)
    {
        return s1._width == s2._width && s1._height == s2._height;
    }

    public static bool operator !=(SizeF s1, SizeF s2)
    {
        return s1._width != s2._width || s1._height != s2._height;
    }

    public bool Equals(SizeF other)
    {
        return _width.Equals(other._width) && _height.Equals(other._height);
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj))
            return false;
        return obj is Size && Equals((Size)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (_width.GetHashCode() * 397) ^ _height.GetHashCode();
        }
    }

    public override string ToString()
    {
        return string.Format("{{Width={0} Height={1}}}", _width.ToString(CultureInfo.InvariantCulture), _height.ToString(CultureInfo.InvariantCulture));
    }
}
