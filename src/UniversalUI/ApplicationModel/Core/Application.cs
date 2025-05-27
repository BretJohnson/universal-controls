// This file is copied, with modifications, from the Uno project

using System;
using System.Diagnostics;
using UniversalUI.Dispatching;

namespace UniversalUI.ApplicationModel.Core;

/// <summary>
/// Enables apps to handle state changes, manage windows, and integrate with a variety of UI frameworks.
/// </summary>
public partial class Application
{
	private Action<object?>? _invalidateRender;
	private Action<object, bool>? _setContinuousRender;

    public static Application Current { get; } = new Application();

    internal Application()
	{
		InitializePlatform();
	}

	partial void InitializePlatform();

    /// <summary>
    /// Gets the dispatcher associated with the UI thread.
    /// </summary>
    public IDispatcher Dispatcher { get; private set; }

    /// <summary>
    /// Occurs when an app is resuming.
    /// </summary>
    public event EventHandler<object>? Resuming;

	/// <summary>
	/// Occurs when the app is suspending.
	/// </summary>
	public event EventHandler<ISuspendingEventArgs>? Suspending;

	/// <summary>
	/// Fired when the app enters the running in the background state.
	/// </summary>
	public event EventHandler<IEnteredBackgroundEventArgs>? EnteredBackground;

	/// <summary>
	/// Fired just before application UI becomes visible.
	/// </summary>
	public event EventHandler<ILeavingBackgroundEventArgs>? LeavingBackground;

	/// <summary>
	/// Raises the <see cref="Resuming"/> event.
	/// </summary>
	internal void RaiseResuming() => Resuming?.Invoke(null, null);

	/// <summary>
	/// Raises the <see cref="Suspending"/> event.
	/// </summary>
	/// <param name="args">Suspending event args.</param>
	internal void RaiseSuspending(ISuspendingEventArgs args) => Suspending?.Invoke(null, args);

	/// <summary>
	/// Raises the <see cref="EnteredBackground"/> event.
	/// </summary>
	/// <param name="args">Entered background event args.</param>
	internal void RaiseEnteredBackground(IEnteredBackgroundEventArgs args) => EnteredBackground?.Invoke(null, args);

	/// <summary>
	/// Raises the <see cref="LeavingBackground"/> event.
	/// </summary>
	/// <param name="args">Leaving background event args.</param>
	internal void RaiseLeavingBackground(ILeavingBackgroundEventArgs args) => LeavingBackground?.Invoke(null, args);

	/// <summary>
	/// Sets the invalidateRender and setContinuousRender callbacks for this layer.
	/// </summary>
	/// <param name="invalidateRender"></param>
	/// <param name="setContinuousRender"></param>
	internal void SetInvalidateRender(Action<object?> invalidateRender, Action<object, bool> setContinuousRender)
	{
		Debug.Assert(_invalidateRender is null);
		Debug.Assert(_setContinuousRender is null);

		_invalidateRender ??= invalidateRender;
		_setContinuousRender ??= setContinuousRender;
	}

	/// <summary>
	/// Enables or disables the continuous render mode for the specified visual
	/// </summary>
	internal void SetContinuousRender(object visual, bool enabled)
		=> _setContinuousRender?.Invoke(visual, enabled);

	/// <summary>
	/// Queues a render surface invalidation
	/// </summary>
	internal void QueueInvalidateRender(object? visual)
		=> _invalidateRender?.Invoke(visual);
}
