// This file is generated from IVisualStateGroup.cs. Update the source file to change its contents.

using DependencyProperty = System.Windows.DependencyProperty;

namespace UniversalUI.Wpf
{
    public class VisualStateGroup : UIObject, IVisualStateGroup
    {
        public static readonly DependencyProperty CurrentStateProperty = PropertyUtils.Register(nameof(CurrentState), typeof(VisualState), typeof(VisualStateGroup), null);
        public static readonly DependencyProperty NameProperty = PropertyUtils.Register(nameof(Name), typeof(string), typeof(VisualStateGroup), "");
        public static readonly DependencyProperty StatesProperty = PropertyUtils.Register(nameof(States), typeof(UICollection<IVisualState>), typeof(VisualStateGroup), null);
        
        private UICollection<IVisualState> _states;
        
        public VisualStateGroup()
        {
            _states = new UICollection<IVisualState>(this);
            SetValue(StatesProperty, _states);
        }
        
        public VisualState CurrentState => (VisualState) GetValue(CurrentStateProperty);
        IVisualState IVisualStateGroup.CurrentState => CurrentState;
        
        public string Name => (string) GetValue(NameProperty);
        
        public UICollection<IVisualState> States => _states;
        IUICollection<IVisualState> IVisualStateGroup.States => States;
    }
}
