// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Composition
{
	public partial class SpriteVisual : ContainerVisual
	{
		private CompositionBrush? _brush;

		public SpriteVisual(Compositor compositor) : base(compositor)
		{

		}

		public CompositionBrush? Brush
		{
			get => _brush;
			set => SetProperty(ref _brush, value);
		}

		private protected override void OnPropertyChangedCore(string? propertyName, bool isSubPropertyChange)
		{
			// Call base implementation - Visual calls Compositor.InvalidateRender().
			base.OnPropertyChangedCore(propertyName, isSubPropertyChange);

			switch (propertyName)
			{
				case nameof(Brush):
					OnBrushChangedPartial(Brush);
					break;
#if __SKIA__
				case nameof(Size):
					UpdatePaint();
					break;
#endif
				default:
					break;
			}
		}

		partial void OnBrushChangedPartial(CompositionBrush? brush);
	}
}
