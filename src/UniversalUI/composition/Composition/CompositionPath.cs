// This file is copied, with modifications, from the Uno project

#nullable enable

using UniversalUI.Graphics;

namespace UniversalUI.Composition
{
	public partial class CompositionPath : IGeometrySource2D
	{
		public CompositionPath(IGeometrySource2D source)
		{
			GeometrySource = source;
		}

		internal IGeometrySource2D GeometrySource { get; }
	}
}
