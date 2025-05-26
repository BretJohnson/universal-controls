// This file is copied, with modifications, from the Uno project

using System;
using System.Numerics;
using System.Runtime.InteropServices;
using UniversalUI.Graphics.Effects;
using UniversalUI.Graphics.Effects.Interop;

namespace UniversalUI.Composition.Effects;

[Guid("6152DFC6-9FBA-4810-8CBA-B280AA27BFF6")]
internal class WhiteNoiseEffect : IGraphicsEffect, IGraphicsEffectSource, IGraphicsEffectD2D1Interop
{
	private string _name = "WhiteNoiseEffect";
	private Guid _id = new Guid("6152DFC6-9FBA-4810-8CBA-B280AA27BFF6");

	public string Name
	{
		get => _name;
		set => _name = value;
	}

	public Vector2 Frequency { get; set; } = new(0.01f);

	public Vector2 Offset { get; set; }

	public Guid GetEffectId() => _id;

	public void GetNamedPropertyMapping(string name, out uint index, out GraphicsEffectPropertyMapping mapping)
	{
		switch (name)
		{
			case "Frequency":
				{
					index = 0;
					mapping = GraphicsEffectPropertyMapping.Direct;
					break;
				}
			case "Offset":
				{
					index = 1;
					mapping = GraphicsEffectPropertyMapping.Direct;
					break;
				}
			default:
				{
					index = 0xFF;
					mapping = (GraphicsEffectPropertyMapping)0xFF;
					break;
				}
		}
	}

	public object GetProperty(uint index)
	{
		switch (index)
		{
			case 0:
				return Frequency;
			case 1:
				return Offset;
			default:
				return null;
		}
	}

	public uint GetPropertyCount() => 2;
	public IGraphicsEffectSource GetSource(uint index) => throw new NotSupportedException();
	public uint GetSourceCount() => 0;
}
