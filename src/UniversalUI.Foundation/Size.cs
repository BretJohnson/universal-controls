﻿// This file is copied, with modifications, from the Uno project.

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using UniversalUI.Converters;
using UniversalUI.Extensions;

namespace UniversalUI;

[DebuggerDisplay("{DebugDisplay,nq}")]
[TypeConverter(typeof(SizeConverter))]
public struct Size
{
	// These are public in WinUI (with the underscore!), but we don't want to expose it for now at least.
	private float _width;
	private float _height;

	public Size(float width, float height)
	{
		// TODO: Disallow nagative, as WinUI does.
		_width = width;
		_height = height;
	}

	public Size(double width, double height)
		: this((float)width, (float)height)
	{
	}

	public static Size Empty => new Size(double.NegativeInfinity, double.NegativeInfinity);

    public static Size Infinity => new Size(double.PositiveInfinity, double.PositiveInfinity);

    public bool IsEmpty => double.IsNegativeInfinity(Width) && double.IsNegativeInfinity(Height);

	public double Height
	{
		get => _height;
		// TODO: Disallow negative, as WinUI does.
		set => _height = (float)value;
	}

	public double Width
	{
		get => _width;
		// TODO: Disallow negative, as WinUI does.
		set => _width = (float)value;
	}

    public double AspectRatio()
    {
        var w = Width;
        var h = Height;
        switch (w)
        {
            case double.NegativeInfinity:
                return -1;
            case double.PositiveInfinity:
                return 1;
            case double.NaN:
                return 1;
            case 0.0d:
                return 1;
        }
        switch (h)
        {
            case double.NegativeInfinity:
                return -1;
            case double.PositiveInfinity:
                return 1;
            case double.NaN:
                return 1;
            case 0.0d:
                return 1; // special case
            case 1.0d:
                return w;
        }
        return w / h;
    }

	public override bool Equals(object? o)
	{
		if (o is Size other)
		{
			return other.Width.Equals(Width)
				&& other.Height.Equals(Height);
		}

		return false;
	}

	public bool Equals(Size value) =>
		value.Width.Equals(Width)
		&& value.Height.Equals(Height);

	public override int GetHashCode() => Width.GetHashCode() ^ Height.GetHashCode();

	public override string ToString()
	{
		var sb = new StringBuilder(8);
		sb.Append(Width.ToStringInvariant());
		sb.Append(',');
		sb.Append(Height.ToStringInvariant());
		return sb.ToString();
	}

	internal string ToString(string format)
	{
		var sb = new StringBuilder(8);
		sb.Append(Width.ToString(format, CultureInfo.InvariantCulture));
		sb.Append(',');
		sb.Append(Height.ToString(format, CultureInfo.InvariantCulture));
		return sb.ToString();
	}

	internal string ToDebugString()
		=> FormattableString.Invariant($"{Width:F2}x{Height:F2}");

	public static bool operator ==(Size size1, Size size2) => size1.Equals(size2);

	public static bool operator !=(Size size1, Size size2) => !size1.Equals(size2);

	private string DebugDisplay => $"{Width:f1}x{Height:f1}";
}
