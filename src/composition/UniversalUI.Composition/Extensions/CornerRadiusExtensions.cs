// This file is copied, with modifications, from the Uno project

using System;
using System.Globalization;
using UniversalUI.Helpers;

namespace UniversalUI.Composition.Extensions;

internal static class CornerRadiusExtensions
{
    /// <summary>
    /// Retrieves the actual inner and outer radii.
    /// </summary>
    /// <param name="cornerRadius">Corner radius.</param>
    /// <param name="elementSize">Element size.</param>
    /// <param name="borderThickness">Border thickness.</param>
    /// <returns>Full corner radius.</returns>
    internal static FullCornerRadius GetRadii(this CornerRadius cornerRadius, Size elementSize, Thickness borderThickness)
	{
		if (cornerRadius == CornerRadius.None)
		{
			return FullCornerRadius.None;
		}

		var outer = cornerRadius.GetRadii(elementSize, borderThickness, true);
		var inner = cornerRadius.GetRadii(elementSize, borderThickness, false);
		return new FullCornerRadius(outer, inner);
	}

    /// <summary>
    /// Retrieves the non-uniform radii for a border.
    /// </summary>
    /// <param name="cornerRadius">Corner radius</param>
    /// <param name="elementSize">Element size.</param>
    /// <param name="borderThickness">Border thickness.</param>
    /// <param name="outer">True to return outer corner radii, false for inner.</param>
    /// <returns>Radii.</returns>
    private static NonUniformCornerRadius GetRadii(this CornerRadius cornerRadius, Size elementSize, Thickness borderThickness, bool outer)
	{
		var halfLeftBorder = borderThickness.Left * 0.5;
		var halfTopBorder = borderThickness.Top * 0.5;
		var halfRightBorder = borderThickness.Right * 0.5;
		var halfBottomBorder = borderThickness.Bottom * 0.5;

		double leftTopArc, topLeftArc, topRightArc, rightTopArc, rightBottomArc, bottomRightArc, leftBottomArc, bottomLeftArc;
		leftTopArc = topLeftArc = topRightArc = rightTopArc = rightBottomArc = bottomRightArc = leftBottomArc = bottomLeftArc = 0;

		if (outer)
		{
			if (!MathHelpers.IsCloseReal(cornerRadius.TopLeft, 0.0f))
			{
				leftTopArc = cornerRadius.TopLeft + halfLeftBorder;
				topLeftArc = cornerRadius.TopLeft + halfTopBorder;
			}

			if (!MathHelpers.IsCloseReal(cornerRadius.TopRight, 0.0f))
			{
				topRightArc = cornerRadius.TopRight + halfTopBorder;
				rightTopArc = cornerRadius.TopRight + halfRightBorder;
			}

			if (!MathHelpers.IsCloseReal(cornerRadius.BottomRight, 0.0f))
			{
				rightBottomArc = cornerRadius.BottomRight + halfRightBorder;
				bottomRightArc = cornerRadius.BottomRight + halfBottomBorder;
			}

			if (!MathHelpers.IsCloseReal(cornerRadius.BottomLeft, 0.0f))
			{
				bottomLeftArc = cornerRadius.BottomLeft + halfBottomBorder;
				leftBottomArc = cornerRadius.BottomLeft + halfLeftBorder;
			}
		}
		else
		{
			leftTopArc = Math.Max(0.0f, cornerRadius.TopLeft - halfLeftBorder);
			topLeftArc = Math.Max(0.0f, cornerRadius.TopLeft - halfTopBorder);
			topRightArc = Math.Max(0.0f, cornerRadius.TopRight - halfTopBorder);
			rightTopArc = Math.Max(0.0f, cornerRadius.TopRight - halfRightBorder);
			rightBottomArc = Math.Max(0.0f, cornerRadius.BottomRight - halfRightBorder);
			bottomRightArc = Math.Max(0.0f, cornerRadius.BottomRight - halfBottomBorder);
			bottomLeftArc = Math.Max(0.0f, cornerRadius.BottomLeft - halfBottomBorder);
			leftBottomArc = Math.Max(0.0f, cornerRadius.BottomLeft - halfLeftBorder);
		}

		// Adjust the corner radius to fit element size
		// When neighboring corners "overlap", we distribute
		// them "fairly" along the side.
		double ratio;

		if (leftTopArc + rightTopArc > elementSize.Width)
		{
			ratio = leftTopArc / (leftTopArc + rightTopArc);
			leftTopArc = ratio * elementSize.Width;
			rightTopArc = elementSize.Width - leftTopArc;
		}

		if (topRightArc + bottomRightArc > elementSize.Height)
		{
			ratio = topRightArc / (topRightArc + bottomRightArc);
			topRightArc = ratio * elementSize.Height;
			bottomRightArc = elementSize.Height - topRightArc;
		}

		if (rightBottomArc + leftBottomArc > elementSize.Width)
		{
			ratio = rightBottomArc / (rightBottomArc + leftBottomArc);
			rightBottomArc = ratio * elementSize.Width;
			leftBottomArc = elementSize.Width - rightBottomArc;
		}

		if (bottomLeftArc + topLeftArc > elementSize.Height)
		{
			ratio = bottomLeftArc / (bottomLeftArc + topLeftArc);
			bottomLeftArc = ratio * elementSize.Height;
			topLeftArc = elementSize.Height - bottomLeftArc;
		}

		return new(
			new((float)leftTopArc, (float)topLeftArc),
			new((float)rightTopArc, (float)topRightArc),
			new((float)rightBottomArc, (float)bottomRightArc),
			new((float)leftBottomArc, (float)bottomLeftArc));
	}
}
