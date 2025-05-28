// This file is copied, with modifications, from the Uno project

namespace UniversalUI.Logging;

public interface IExternalLoggerFactory
{
	IExternalLogger CreateLogger(string categoryName);
}
