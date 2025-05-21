using System.ComponentModel;

namespace UniversalUI.Controls
{
    [UIModelObject]
    public interface IStackBase : IPanel
    {
        /// <summary>
        /// Gets or sets a uniform distance (in pixels) between stacked items. The default is 0. This value can be any value equal to or greater than 0.
        /// </summary>
        [DefaultValue(0.0)]
        public double Spacing { get; set; }
    }
}
