// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Composition
{
	public partial class CompositionColorGradientStop : CompositionObject
	{
		private float _offset;
		private Color _color;

		internal CompositionColorGradientStop(Compositor compositor)
			: base(compositor)
		{

		}

		public float Offset
		{
			get => _offset;
			set => SetProperty(ref _offset, value);
		}

		public Color Color
		{
			get => _color;
			set => SetProperty(ref _color, value);
		}
	}
}
