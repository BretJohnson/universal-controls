// This file is copied, with modifications, from the Uno project

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uno.UI.Composition;

internal interface ICompositionPathCommandsProvider
{
	List<CompositionPathCommand> Commands { get; }
}
