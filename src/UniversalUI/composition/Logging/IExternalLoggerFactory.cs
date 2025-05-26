// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Logging
{
	internal interface IExternalLoggerFactory
	{
		IExternalLogger CreateLogger(string categoryName);
	}
}
