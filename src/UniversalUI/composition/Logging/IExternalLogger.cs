// This file is copied, with modifications, from the Uno project

#nullable enable
using System;

namespace UniversalUI.Logging
{
	internal interface IExternalLogger
	{
		void Log(LogLevel logLevel, string? message, Exception? exception = null);
		LogLevel LogLevel { get; }
	}
}
