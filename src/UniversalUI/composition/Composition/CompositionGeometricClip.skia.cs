// This file is copied, with modifications, from the Uno project

using System;
using SkiaSharp;

namespace UniversalUI.Composition;

partial class CompositionGeometricClip
{
	private protected override Rect? GetBoundsCore(Visual visual)
	{
		if (Geometry is not null)
		{
			var geometry = Geometry.BuildGeometry();

			if (geometry is SkiaGeometrySource2D skiaGeometrySource)
			{
				return skiaGeometrySource.Geometry.TightBounds.ToRect();
			}
			else
			{
				throw new InvalidOperationException($"Clipping with source {geometry} is not supported");
			}
		}

		return null;
	}

	internal override SKPath? GetClipPath(Visual visual)
	{
		if (Geometry is not null)
		{
			var geometry = Geometry.BuildGeometry();

			if (geometry is SkiaGeometrySource2D geometrySource)
			{
				var path = geometrySource.Geometry;
				if (!TransformMatrix.IsIdentity)
				{
					var transformedPath = new SKPath();
					path.Transform(TransformMatrix.ToSKMatrix(), transformedPath);
					path = transformedPath;
				}

				return path;
			}
			else
			{
				throw new InvalidOperationException($"Clipping with source {geometry} is not supported");
			}
		}

		return null;
	}
}
