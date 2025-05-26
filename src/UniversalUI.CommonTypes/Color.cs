// This file is copied, with modifications, from the Uno project.

using System;
using System.Runtime.InteropServices;

namespace UniversalUI;

[StructLayout(LayoutKind.Explicit)]
public struct Color : IFormattable
{
	/// <summary>
	/// Alias individual fields to avoid bitshifting and GetHashCode / compare costs
	/// </summary>
	[FieldOffset(0)]
	private uint _color;

	//
	// This memory layout assumes that the system uses little-endianness.
	//
	[FieldOffset(3)]
	private byte _a;
	[FieldOffset(2)]
	private byte _r;
	[FieldOffset(1)]
	private byte _g;
	[FieldOffset(0)]
	private byte _b;

	public byte A { get => _a; set => _a = value; }

	public byte B { get => _b; set => _b = value; }

	public byte G { get => _g; set => _g = value; }

	public byte R { get => _r; set => _r = value; }

	public bool IsTransparent => _a == 0;

	public static Color FromArgb(byte a, byte r, byte g, byte b) => new Color(a, r, g, b);

    /// <summary>
    /// Takes a color code as an ARGB, RGB, #ARGB, #RGB string and returns a color.
    ///
    /// Remark: if single digits are used to define the color, they will
    /// be duplicated (example: FFD8 will become FFFFDD88)
    /// </summary>
    /// <param name="colorCode"></param>
    /// <returns></returns>
    public static Color FromArgb(string colorCode)
    {
        byte a, r, b, g;

        int len = colorCode.Length;
        // skip a starting `#` if present
        int offset = (len > 0 && colorCode[0] == '#' ? 1 : 0);
        len -= offset;

        // deal with an optional alpha value
        if (len == 4)
        {
            a = ToByte(colorCode[offset++]);
            a = (byte)(a << 4 + a);
            len = 3;
        }
        else if (len == 8)
        {
            a = (byte)((ToByte(colorCode[offset++]) << 4) + ToByte(colorCode[offset++]));
            len = 6;
        }
        else
        {
            a = 0xFF;
        }

        // then process the required R G and B values
        if (len == 3)
        {
            r = ToByte(colorCode[offset++]);
            r = (byte)(r << 4 + r);
            g = ToByte(colorCode[offset++]);
            g = (byte)(g << 4 + g);
            b = ToByte(colorCode[offset++]);
            b = (byte)(b << 4 + b);
        }
        else if (len == 6)
        {
            r = (byte)((ToByte(colorCode[offset++]) << 4) + ToByte(colorCode[offset++]));
            g = (byte)((ToByte(colorCode[offset++]) << 4) + ToByte(colorCode[offset++]));
            b = (byte)((ToByte(colorCode[offset++]) << 4) + ToByte(colorCode[offset++]));
        }
        else
        {
            throw new ArgumentException($"Cannot parse color '{colorCode}'.");
        }

        return new Color(a, r, g, b);
    }

    private static byte ToByte(char c)
    {
        if (c >= '0' && c <= '9')
        {
            return (byte)(c - '0');
        }
        else if (c >= 'a' && c <= 'f')
        {
            return (byte)(c - 'a' + 10);
        }
        else if (c >= 'A' && c <= 'F')
        {
            return (byte)(c - 'A' + 10);
        }
        else
        {
            throw new FormatException($"The character {c} is not valid for a Color string");
        }
    }

	public Color(byte a, byte r, byte g, byte b)
	{
		// Required for field initialization rules in C#
		_color = 0;

		_b = b;
		_g = g;
		_r = r;
		_a = a;
	}

	internal Color(uint color)
	{
		// Required for field initialization rules in C#
		_b = 0;
		_g = 0;
		_r = 0;
		_a = 0;

		_color = color;
	}

	public override bool Equals(object? o) => o is Color color && Equals(color);

	public bool Equals(Color color) =>
		color._color == _color;

	public override int GetHashCode() => (int)_color;

	public override string ToString() => ToString(null);

	public static bool operator ==(Color color1, Color color2) => color1.Equals(color2);

	public static bool operator !=(Color color1, Color color2) => !color1.Equals(color2);

	/// <summary>
	/// Returns value indicating color's luminance.
	/// Values lower than 0.5 mean dark color, above 0.5 light color.
	/// </summary>
	internal double Luminance => (0.299 * _r + 0.587 * _g + 0.114 * _b) / 255;

	// Note: This method has an equivalent in Toolkit.ColorExtensions for usage with Windows
	internal Color WithOpacity(double opacity) => new((byte)(_a * opacity), _r, _g, _b);

	internal uint AsUInt32() => _color;

	string IFormattable.ToString(string format, IFormatProvider formatProvider) => ToString(formatProvider);

	private string ToString(IFormatProvider? formatProvider) => string.Format(formatProvider, "#{0:X2}{1:X2}{2:X2}{3:X2}", _a, _r, _g, _b);
}
