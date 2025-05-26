// This file is copied, with modifications, from the Uno project.

using System;

namespace UniversalUI.Dispatching;

public interface IDispatcher
{
    /// <summary>
    /// Gets a value that specifies whether the event dispatcher has access to the current thread or not.
    /// </summary>
    public bool HasThreadAccess { get; }

    /// <summary>
    /// Adds a task to the dispatcher queue that will be executed on the thread associated with the dispatcher.
    /// </summary>
    /// <param name="callback">A delegate to the task to execute.</param>
    /// <returns>True if the task was added to the queue. Otherwise, false.</returns>
    public bool TryEnqueue(Action callback);
}