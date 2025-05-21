// This file is generated from IVisualStateGroup.cs. Update the source file to change its contents.

using UniversalUI.DefaultImplementations;

namespace AnywhereControls.Blazor
{
    public class VisualStateGroup : StandardUIObject, IVisualStateGroup
    {
        public static readonly UIProperty CurrentStateProperty = new UIProperty(nameof(CurrentState), null, readOnly:true);
        public static readonly UIProperty NameProperty = new UIProperty(nameof(Name), "", readOnly:true);
        public static readonly UIProperty StatesProperty = new UIProperty(nameof(States), null, readOnly:true);
        
        private UICollection<IVisualState> _states;
        
        public VisualStateGroup()
        {
            _states = new UICollection<IVisualState>(this);
            SetValue(StatesProperty, _states);
        }
        
        public IVisualState CurrentState => (VisualState) GetNonNullValue(CurrentStateProperty);
        
        public string Name => (string) GetNonNullValue(NameProperty);
        
        public IUICollection<IVisualState> States => (UICollection<IVisualState>) GetNonNullValue(StatesProperty);
    }
}
