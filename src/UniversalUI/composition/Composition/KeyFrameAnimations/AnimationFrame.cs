// This file is copied, with modifications, from the Uno project

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalUI.Composition;

internal struct AnimationKeyFrame<T>
{
	public T Value;
	public CompositionEasingFunction EasingFunction;
}
