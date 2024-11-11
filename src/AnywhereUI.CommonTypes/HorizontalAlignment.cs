namespace AnywhereUI;

/// <summary>
/// Indicates where an element should be displayed on the horizontal axis relative to the allocated layout slot of the parent element.
/// </summary>
public enum HorizontalAlignment
{
    /// <summary>
    /// An element aligned to the left of the layout slot for the parent element.
    /// </summary>
    Left = 0,

    /// <summary>
    /// An element aligned to the center of the layout slot for the parent element.
    /// </summary>
    Center = 1,

    /// <summary>
    /// An element aligned to the right of the layout slot for the parent element.
    /// </summary>
    Right = 2,

    /// <summary>
    /// An element stretched to fill the entire layout slot of the parent element.
    /// </summary>
    Stretch = 3,
}
