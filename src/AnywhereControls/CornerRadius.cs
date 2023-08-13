namespace Microsoft.StandardUI
{
    /// <summary>
    /// Describes the characteristics of a rounded corner, such as can be applied to a Border.
    /// </summary>
    public struct CornerRadius
    {
        public static readonly CornerRadius Default = new();

        /// <summary>
        /// The radius of rounding, in pixels, of the lower-left corner of the object where a CornerRadius is applied.
        /// </summary>
        public double BottomLeft { get; set; }

        /// <summary>
        /// The radius of rounding, in pixels, of the lower-right corner of the object where a CornerRadius is applied.
        /// </summary>
        public double BottomRight { get; set; }

        /// <summary>
        /// The radius of rounding, in pixels, of the upper-left corner of the object where a CornerRadius is applied.
        /// </summary>
        public double TopLeft { get; set; }

        /// <summary>
        /// The radius of rounding, in pixels, of the upper-right corner of the object where a CornerRadius is applied.
        /// </summary>
        public double TopRight { get; set; }
    }
}
