namespace Microsoft.StandardUI.Text
{
    /// <summary>
    /// The degree to which a font has been stretched, compared to the normal aspect ratio of that font.
    /// </summary>
    public enum FontStretch
    {
        /// <summary>
        /// No defined font stretch
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// An ultra-condensed font stretch (50% of normal)
        /// </summary>
        UltraCondensed = 1,

        /// <summary>
        /// An extra-condensed font stretch (62.5% of normal)
        /// </summary>
        ExtraCondensed = 2,

        /// <summary>
        /// A condensed font stretch (75% of normal)
        /// </summary>
        Condensed = 3,

        /// <summary>
        /// A semi-condensed font stretch (87.5% of normal)
        /// </summary>
        SemiCondensed = 4,

        /// <summary>
        /// The normal font stretch that all other font stretch values relate to (100%)
        /// </summary>
        Normal = 5,

        /// <summary>
        /// A semi-expanded font stretch (112.5% of normal)
        /// </summary>
        SemiExpanded = 6,

        /// <summary>
        /// An expanded font stretch (125% of normal)
        /// </summary>
        Expanded = 7,

        /// <summary>
        /// An extra-expanded font stretch (150% of normal)
        /// </summary>
        ExtraExpanded = 8,

        /// <summary>
        /// An ultra-expanded font stretch (200% of normal)
        /// </summary>
        UltraExpanded = 9
    }
}
