#nullable enable

namespace UniversalUI.Logging
{
	internal interface IExternalLoggerFactory
	{
		IExternalLogger CreateLogger(string categoryName);
	}
}
