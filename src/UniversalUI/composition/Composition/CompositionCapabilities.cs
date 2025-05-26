// This file is copied, with modifications, from the Uno project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalUI.Composition
{
	public partial class CompositionCapabilities
	{
		private Compositor? _compositor;

		internal CompositionCapabilities(Compositor? compositor) => _compositor = compositor;

		public CompositionCapabilities() : this(Compositor.GetSharedCompositor())
		{
		}

		public static CompositionCapabilities GetForCurrentView() => new CompositionCapabilities(Compositor.GetSharedCompositor());
	}
}
