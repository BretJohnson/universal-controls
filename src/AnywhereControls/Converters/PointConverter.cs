using System;
using System.Globalization;
using System.Text;
using Microsoft.Maui.Graphics;

namespace AnywhereControls.Converters
{
    public static class PointConverter
    {
        public static Point ConvertFromString(string value)
        {
            if (value != null)
            {
                string[] xy = value.Split(',');
                if (xy.Length == 2 &&
                    double.TryParse(xy[0], NumberStyles.Number, CultureInfo.InvariantCulture, out double x) &&
                    double.TryParse(xy[1], NumberStyles.Number, CultureInfo.InvariantCulture, out double y))
                    return new Point(x, y);
            }

            throw new InvalidOperationException($"Cannot convert \"{value}\" into {typeof(Point)}");
        }

        public static string ConvertToString(Point point)
        {
            IFormatProvider formatProvider = CultureInfo.InvariantCulture;

            StringBuilder buffer = new StringBuilder();
            buffer.Append(point.X.ToString(formatProvider));
            buffer.Append(",");
            buffer.Append(point.Y.ToString(formatProvider));

            return buffer.ToString();
        }
    }
}
