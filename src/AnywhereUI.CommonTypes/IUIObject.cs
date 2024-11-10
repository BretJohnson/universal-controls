namespace AnywhereControls;

public interface IUIObject
{
    /// <summary>
    /// Returns the current effective value of a UI property from this object.
    /// </summary>
    /// <param name="property">The property for which to retrieve the value.</param>
    /// <returns>Returns the current effective value.</returns>
    public object? GetValue(IUIProperty property);

    /// <summary>
    /// Sets the local value of a UI property on this object.
    /// </summary>
    /// <param name="property">The property to set.</param>
    /// <param name="value">The new local value.</param>
    public void SetValue(IUIProperty property, object? value);

    /// <summary>
    /// Clears the local value of a a UI property on this object.
    /// </summary>
    /// <param name="property">The property to clear.</param>
    public void ClearValue(IUIProperty property);
}
