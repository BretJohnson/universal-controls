// This file is copied, with modifications, from the Uno project

#nullable enable

using System;

namespace UniversalUI.Composition
{
	public partial class VisualCollection : global::UniversalUI.Composition.CompositionObject, global::System.Collections.Generic.IEnumerable<global::UniversalUI.Composition.Visual>
	{
		partial void InsertAbovePartial(Visual newChild, Visual sibling)
		{
		}

		partial void InsertAtBottomPartial(Visual newChild)
		{
		}

		partial void InsertAtTopPartial(Visual newChild)
		{
		}

		partial void InsertBelowPartial(Visual newChild, Visual sibling)
		{
		}

		partial void RemoveAllPartial()
		{
		}

		partial void RemovePartial(Visual child)
		{
		}
	}
}
