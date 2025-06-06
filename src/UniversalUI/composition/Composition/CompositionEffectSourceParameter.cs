// This file is copied, with modifications, from the Uno project

using UniversalUI.Graphics.Effects;

namespace UniversalUI.Composition;

public partial class CompositionEffectSourceParameter : IGraphicsEffectSource
{
	private string _name;

	public CompositionEffectSourceParameter(string name) => _name = name;

	public string Name => _name;
}
