using System;
using System.ComponentModel;
using System.Globalization;
using AnywhereControls.Converters;

namespace AnywhereControls
{
    /// <summary>
    /// Represents number values that specify a height and width.
    /// </summary>
    [TypeConverter(typeof(SizeTypeConverter))]
    public readonly struct Size
    {
        private readonly double _width;
        private readonly double _height;

        public static readonly Size Zero;
        public static readonly Size Infinity = new Size(double.PositiveInfinity, double.PositiveInfinity);
        public static readonly Size Default = Zero;

        public Size(double width, double height)
        {
            if (double.IsNaN(width))
                throw new ArgumentException("NaN is not a valid value for width");
            if (double.IsNaN(height))
                throw new ArgumentException("NaN is not a valid value for height");
            _width = width;
            _height = height;
        }

        public double Width => _width;
        public double Height => _height;

        public static bool operator ==(Size s1, Size s2)
        {
            return s1._width == s2._width && s1._height == s2._height;
        }

        public static bool operator !=(Size s1, Size s2)
        {
            return s1._width != s2._width || s1._height != s2._height;
        }

        public bool Equals(Size other)
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
}
