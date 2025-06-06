// This file is copied, with modifications, from the Uno project

using System;
using System.Collections.Generic;
using UniversalUI.Graphics.Effects;
using UniversalUI.Graphics.Effects.Interop;

namespace UniversalUI.Composition;

public partial class CompositionEffectFactory : CompositionObject
{
	private IGraphicsEffect _effect;
	private IEnumerable<string>? _animatableProperties;

	private CompositionEffectFactoryLoadStatus _loadStatus;
	private Exception? _extendedError;

	internal CompositionEffectFactory(Compositor compositor, IGraphicsEffect effect, IEnumerable<string>? animatableProperties = null) : base(compositor)
	{
		if (effect is null)
		{
			throw new ArgumentNullException(nameof(effect));
		}

		if (!effect.IsSupported())
		{
			throw new ArgumentException("Unsupported effect type.", nameof(effect));
		}

		_loadStatus = default;
		_extendedError = null;

		_effect = effect;
		_animatableProperties = animatableProperties;
	}

	public CompositionEffectBrush? CreateBrush() => new(Compositor, _effect, _animatableProperties);

	public CompositionEffectFactoryLoadStatus LoadStatus => _loadStatus;
	public Exception? ExtendedError => _extendedError;
}
