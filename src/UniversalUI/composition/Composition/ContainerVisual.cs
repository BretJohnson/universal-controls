// This file is copied, with modifications, from the Uno project

using System;

namespace UniversalUI.Composition;

public partial class ContainerVisual : Visual
{
	internal ContainerVisual() : base(null!) => throw new NotSupportedException("Use the ctor with Compositor");

	internal ContainerVisual(Compositor compositor) : base(compositor)
	{
		Children = new VisualCollection(compositor, this);
		InitializePartial();
	}

	partial void InitializePartial();

	public VisualCollection Children { get; }
}
