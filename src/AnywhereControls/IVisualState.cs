using System.ComponentModel;

namespace Microsoft.StandardUI
{
    [UIModelObject]
    public interface IVisualState : IUIObject
    {
        /// <summary>
        /// Gets the name of the VisualState.
        /// </summary>
        [DefaultValue("")]
        public string Name { get; }

        /// <summary>
        /// Gets a collection of ISetter objects that define discrete property values that control the appearance of IUIElements when this IVisualState is applied.
        /// </summary>
        public IUICollection<ISetter> Setters { get; }
    }
}
