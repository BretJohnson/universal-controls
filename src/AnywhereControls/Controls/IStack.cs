using System.ComponentModel;

namespace Microsoft.StandardUI.Controls
{
    [StandardPanel]
    public interface IStack : IStackBase
    {
        /// <summary>
        /// The dimension by which child elements are stacked. The default is Vertical.
        /// </summary>
        [DefaultValue(Orientation.Vertical)]
        public Orientation Orientation { get; set; }
    }
}
