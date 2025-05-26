// This file is copied, with modifications, from the Uno project

#nullable enable

namespace UniversalUI.Logging
{
	internal interface IExternalLoggerFactory
	{
		IExternalLogger CreateLogger(string categoryName);
	}
}
