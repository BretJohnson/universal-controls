namespace Microsoft.StandardUI
{
    [UIModelObject]
    public interface IVisualStateManager
    {
#if LATER
        /// <summary>
        /// Transitions a control between two states, by requesting a new VisualState by name.
        /// </summary>
        /// <param name="control">The control to transition between states.</param>
        /// <param name="stateName">The state to transition to.</param>
        /// <param name="useTransitions"></param>
        /// <returns></returns>
        public bool GoToState(IUIElement control, string stateName, bool useTransitions);
#endif
    }
}
