// This file is copied, with modifications, from the Uno project

#nullable enable

using System.Numerics;

namespace UniversalUI.Composition
{
	public partial class CompositionLineGeometry : CompositionGeometry
	{
		private Vector2 _start;
		private Vector2 _end;

		internal CompositionLineGeometry(Compositor compositor) : base(compositor)
		{

		}

		public Vector2 Start
		{
			get => _start;
			set => SetProperty(ref _start, value);
		}

		public Vector2 End
		{
			get => _end;
			set => SetProperty(ref _end, value);
		}
	}
}
