// This file is copied, with modifications, from the Uno project.

namespace UniversalUI.Media
{
	public partial class GeneralTransform : UIObject
	{
		protected GeneralTransform() { }

		public GeneralTransform Inverse => InverseCore;

		protected virtual GeneralTransform InverseCore { get; }

		public Point TransformPoint(Point point)
		{
			TryTransform(point, out var transformed);
			return transformed;
		}

		public bool TryTransform(Point inPoint, out Point outPoint)
			=> TryTransformCore(inPoint, out outPoint);

		protected virtual bool TryTransformCore(Point inPoint, out Point outPoint)
		{
			outPoint = inPoint;
			return false;
		}

		public Rect TransformBounds(Rect rect)
			=> TransformBoundsCore(rect);

		protected virtual Rect TransformBoundsCore(Rect rect)
			=> rect;
	}
}
