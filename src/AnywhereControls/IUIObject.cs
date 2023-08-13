namespace Microsoft.StandardUI
{
    [UIModelObject]
    public interface IUIObject
    {
        /// <summary>
        /// Returns the current effective value of a UI property from this object.
        /// </summary>
        /// <param name="property">The property for which to retrieve the value.</param>
        /// <returns>Returns the current effective value.</returns>
        public object? GetValue(IUIProperty property);

        /// <summary>
        /// Returns the local value of a property, if a local value is set.
        /// </summary>
        /// <param name="property">The property for which to retrieve the local value.</param>
        /// <returns>Returns the local value, or returns the sentinel value UnsetValue if no local value is set.</returns>
        public object? ReadLocalValue(IUIProperty property);

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
}
