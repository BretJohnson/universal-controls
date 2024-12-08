// This file is generated from IVisualState.cs. Update the source file to change its contents.

using AnywhereUI.DefaultImplementations;

namespace AnywhereControls.Blazor
{
    public class VisualState : UIObject, IVisualState
    {
        public static readonly UIProperty NameProperty = new UIProperty(nameof(Name), "", readOnly:true);
        public static readonly UIProperty SettersProperty = new UIProperty(nameof(Setters), null, readOnly:true);
        
        private UICollection<ISetter> _setters;
        
        public VisualState()
        {
            _setters = new UICollection<ISetter>(this);
            SetValue(SettersProperty, _setters);
        }
        
        public string Name => (string) GetNonNullValue(NameProperty);
        
        public IUICollection<ISetter> Setters => (UICollection<ISetter>) GetNonNullValue(SettersProperty);
    }
}
