// This file is copied, with modifications, from the Uno project

using Windows.Graphics;

namespace UniversalUI.Composition
{
	public partial class CompositionPathGeometry : CompositionGeometry
	{
		private CompositionPath? _path;

		internal CompositionPathGeometry(Compositor compositor, CompositionPath? path = null) : base(compositor)
		{
			Path = path;
		}

		public CompositionPath? Path
		{
			get => _path;
			set => SetObjectProperty(ref _path, value);
		}
	}
}
