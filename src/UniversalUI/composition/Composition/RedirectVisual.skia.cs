// This file is copied, with modifications, from the Uno project

using SkiaSharp;
using Uno.UI.Composition;

namespace UniversalUI.Composition
{
	public partial class RedirectVisual : ContainerVisual
	{
		internal override void Paint(in PaintingSession session)
		{
			base.Paint(in session);

			if (Source is not null && session.Canvas is { } canvas)
			{
				Source.RenderRootVisual(canvas, null);
			}
		}

		internal override bool CanPaint() => Source?.CanPaint() ?? false;
		internal override bool RequiresRepaintOnEveryFrame => true;
	}
}
