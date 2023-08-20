using System;
using CommonUI.Converters;
using System.ComponentModel;

namespace CommonUI;

/// <summary>
/// Describes a color in terms of alpha, red, green, and blue channels.
/// </summary>
[TypeConverter(typeof(ColorTypeConverter))]
public struct Color
{
    public static readonly Color Default = new Color(0, 0, 0, 0);

    /// <summary>
    /// Gets or sets the sRGB alpha channel value of the color.
    /// </summary>
    public byte A { get; set; }

    /// <summary>
    /// Gets or sets the sRGB blue channel value of the color.
    /// </summary>
    public byte B { get; set; }

    /// <summary>
    /// Gets or sets the sRGB green channel value of the color.
    /// </summary>
    public byte G { get; set; }

    /// <summary>
    /// Gets or sets the sRGB red channel value of the color.
    /// </summary>
    public byte R { get; set; }

    public static Color FromArgb(byte a, byte r, byte g, byte b) => new Color(a, r, g, b);

    public static Color FromRgb(byte r, byte g, byte b) => FromArgb(255, r, g, b);

    public static Color FromHex(string hex)
    {
        if (!FromHex(hex, out Color value))
            throw new System.FormatException($"Color '{hex}' isn't a valid hex color");

        return value;
    }

    /// <summary>
    /// Creates a Color structure from a 32-bit RGBA value
    /// </summary>
    public static Color FromRgba(int rgba)
    {
        byte[] bytes = BitConverter.GetBytes(rgba);
        return FromArgb(bytes[3], bytes[0], bytes[1], bytes[2]);
    }

    public static bool FromHex(string hex, out Color color)
    {
        color = Color.Default;

        if (hex.Length < 3)
            return false;

        int idx = (hex[0] == '#') ? 1 : 0;

        switch (hex.Length - idx)
        {
            case 3: //#rgb => ffrrggbb
                byte t1 = ToHexD(hex[idx++]);
                byte t2 = ToHexD(hex[idx++]);
                byte t3 = ToHexD(hex[idx]);
                color = FromRgb(t1, t2, t3);
                return true;

            case 4: //#argb => aarrggbb
                byte f1 = ToHexD(hex[idx++]);
                byte f2 = ToHexD(hex[idx++]);
                byte f3 = ToHexD(hex[idx++]);
                byte f4 = ToHexD(hex[idx]);
                color = FromArgb(f1, f2, f3, f4);
                return true;

            case 6: //#rrggbb => ffrrggbb
                color = FromRgb(
                    (byte)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                    (byte)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                    (byte)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])));
                return true;

            case 8: //#aarrggbb
                byte a1 = (byte)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++]));
                color = FromArgb(
                    a1,
                    (byte)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                    (byte)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx++])),
                    (byte)(ToHex(hex[idx++]) << 4 | ToHex(hex[idx])));
                return true;

            default: //everything else will result in unexpected results
                return false;
        }
    }

    public Color(byte a, byte r, byte g, byte b)
    {
        A = a;
        R = r;
        G = g;
        B = b;
    }

    public Color WithA(byte a) => new Color(a, R, G, B);

    public Color WithR(byte r) => new Color(A, r, G, B);

    public Color WithG(byte g) => new Color(A, R, g, B);

    public Color WithB(byte b) => new Color(A, R, G, b);

    private static byte ToHex(char c)
    {
        ushort x = (ushort)c;
        if (x >= '0' && x <= '9')
            return (byte)(x - '0');

        x |= 0x20;
        if (x >= 'a' && x <= 'f')
            return (byte)(x - 'a' + 10);
        return 0;
    }

    private static byte ToHexD(char c)
    {
        byte j = ToHex(c);
        return (byte)((j << 4) | j);
    }

    public Color WithA(float v)
    {
        throw new NotImplementedException();
    }
}
